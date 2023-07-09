using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Mvc;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Infra;
using TataGamedom.Models.Infra.DapperRepositories;
using TataGamedom.Models.Interfaces;
using TataGamedom.Models.Services;
using TataGamedom.Models.ViewModels.Games;
using TataGamedom.Models.ViewModels.Products;

namespace TataGamedom.Controllers
{
	public class ProductsController : Controller
	{
		private AppDbContext db = new AppDbContext();
		[Authorize]
		// GET: Products
		public ActionResult Index()
		{
			IEnumerable<ProductIndexVM> product = GetProducts();
			return View(product);
		}

		private IEnumerable<ProductIndexVM> GetProducts()
		{
			IProductRepository repo = new ProductDapperRepository();
			ProductService service = new ProductService(repo);
			return service.Get();

		}
		[Authorize]
		public ActionResult EditProduct(int id)
		{
			IProductRepository repo = new ProductDapperRepository();
			ProductService service = new ProductService(repo);

			var product = service.Get(id);

			var platformsCodes = db.GamePlatformsCodes
				.Where(code => !code.Products.Any(p => p.GameId == product.GameId) || code.Id == product.GamePlatform)
				.AsEnumerable();

			ViewBag.GamePlatform = new SelectList(platformsCodes, "Id", "Name", product.GamePlatform);
			ViewBag.ProductStatus = new SelectList(db.ProductStatusCodes, "Id", "Name", product.ProductStatus);
			return View(product);
		}
		[HttpPost]
		public ActionResult EditProduct(ProductEditVM vm)
		{
			var currentUserAccount = User.Identity.Name;
			var memberInDb = db.BackendMembers.FirstOrDefault(m => m.Account == currentUserAccount);
			vm.ModifiedBackendMemberId = memberInDb.Id;

			if (!ModelState.IsValid)
			{
				return View(vm);
			}
			var editResult = UpdateProduct(vm);
			if (editResult.IsFail)
			{
				ModelState.AddModelError("", "商品編輯失敗！");
				ViewBag.GamePlatform = new SelectList(db.GamePlatformsCodes, "Id", "Name");
				ViewBag.ProductStatus = new SelectList(db.ProductStatusCodes, "Id", "Name");
				return View(vm);
			}
			return RedirectToAction("Index");
		}

		private Result UpdateProduct(ProductEditVM vm)
		{
			IProductRepository repo = new ProductDapperRepository();
			ProductService service = new ProductService(repo);
			return service.Edit(vm);
		}
		[Authorize]
		public ActionResult EditProducImg(int id)
		{
			var viewModel = new ProductEditImgVM();
			var currentUserAccount = User.Identity.Name;
			var memberInDb = db.BackendMembers.FirstOrDefault(m => m.Account == currentUserAccount);

			// 根据商品ID从数据库中获取所有相关的图片记录
			var productImages = db.ProductImages
				.Where(pi => pi.ProductId == id)
				.ToList();

			// 设置视图模型的商品ID和图片ID
			viewModel.ProductId = id;
			viewModel.Id = productImages.Select(pi => pi.Id).ToList();

			// 设置视图模型的图片列表
			viewModel.Image = productImages.Select(pi => pi.Image).ToList();

			// 设置最后修改时间和修改者信息
			//viewModel.ModifiedTime = DateTime.Now;
			//viewModel.ModifiedTimeBackendMemberId = memberInDb != null ? memberInDb.Id : 0;
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult EditProducImg(ProductEditImgVM viewModel, HttpPostedFileBase[] file)
		{
			if (ModelState.IsValid)
			{
				// 获取当前用户信息
				var currentUserAccount = User.Identity.Name;
				var memberInDb = db.BackendMembers.FirstOrDefault(m => m.Account == currentUserAccount);

				// 根据商品ID从数据库中获取商品记录
				var product = db.Products.FirstOrDefault(p => p.Id == viewModel.ProductId);

				if (product != null)
				{
					// 更新最后修改时间和修改者信息
					product.ModifiedTime = DateTime.Now;
					product.ModifiedBackendMemberId = memberInDb != null ? memberInDb.Id : 0;

					if (viewModel.Image != null)
					{
						for (int i = 0; i < viewModel.Id.Count; i++)
						{
							if (i < viewModel.Image.Count)
							{
								var imageId = viewModel.Id[i];
								var image = viewModel.Image[i];
								var productImage = db.ProductImages.FirstOrDefault(pi => pi.Id == imageId);

								if (productImage != null)
								{
									productImage.Image = image;
								}
							}
						}
					}

					// 处理上传的新图片
					if (file != null && file.Length > 0)
					{
						foreach (var uploadedFile in file)
						{
							if (uploadedFile != null && uploadedFile.ContentLength > 0)
							{
								// 将上传的图片保存到服务器文件系统或数据库
								var fileName = Path.GetFileName(uploadedFile.FileName);
								var filePath = Path.Combine(Server.MapPath("~/Files/Uploads"), fileName);
								uploadedFile.SaveAs(filePath);

								// 创建新的ProductImage记录并保存到数据库
								var newProductImage = new ProductImage
								{
									ProductId = viewModel.ProductId,
									Image = fileName,
									// 设置其他属性值
								};
								db.ProductImages.Add(newProductImage);
							}
						}
					}
					// 保存更改到数据库
					db.SaveChanges();
				}

				return RedirectToAction("EditProducImg", new { productId = viewModel.ProductId });
			}

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult DeleteImage(int id)
		{
			var productImage = db.ProductImages.FirstOrDefault(pi => pi.Id == id);

			if (productImage != null)
			{
				db.ProductImages.Remove(productImage);
				db.SaveChanges();
				return Json(new { success = true });
			}

			return Json(new { success = false });
		}
	}
}