using System;
using System.Collections.Generic;
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
	}
}