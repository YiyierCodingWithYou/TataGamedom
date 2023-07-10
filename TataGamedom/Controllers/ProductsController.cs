using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
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
		[Authorize]
		public ActionResult Upload()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Upload(HttpPostedFileBase file)
		{
			ViewBag.Message = "匯入成功";
			if (file != null)
			{
				Stream stream = file.InputStream; //使用Stream(流)對檔案進行操作
				DataTable dataTable = new DataTable();
				IWorkbook wb;
				ISheet sheet;
				IRow headerRow;
				int cellCount; //紀錄共有幾欄

				try
				{
					//依excel版本，NPOI載入檔案
					if (file.FileName.ToUpper().EndsWith("XLSX"))
						wb = new XSSFWorkbook(stream); // excel版本(.xlsx)
					else
						wb = new HSSFWorkbook(stream); // excel版本(.xls)

					//取第一個頁籤   
					sheet = wb.GetSheetAt(0);

					//取第一個頁籤的第一列
					headerRow = sheet.GetRow(0);

					//計算出第一列共有多少欄位
					cellCount = headerRow.LastCellNum;

					//迴圈執行第一列的第一個欄位到最後一個欄位，將抓到的值塞進DataTable做完欄位名稱
					for (int i = headerRow.FirstCellNum; i < cellCount; i++)
					{
						dataTable.Columns.Add(new DataColumn(headerRow.GetCell(i).StringCellValue));
					}

					//int j; //計算每一列讀到第幾個欄位
					int column = 1; //計算每一列讀到第幾個欄位

					// 略過第零列(標題列)，一直處理至最後一列
					for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
					{
						//取目前的列(row)
						IRow row = sheet.GetRow(i);

						//若該列的第一個欄位無資料，break跳出
						if (string.IsNullOrEmpty(row.Cells[0].ToString().Trim()))
						{
							break;
						}

						//宣告DataRow
						DataRow dataRow = dataTable.NewRow();
						//宣告ICell
						ICell cell;

						try
						{
							//依先前取得，依每一列的欄位數，逐一設定欄位內容
							for (int j = row.FirstCellNum; j < cellCount; j++)
							{
								//計算每一列讀到第幾個欄位(秀在錯誤訊息上)
								column = j + 1;

								//設定cell為目前第j欄位
								cell = row.GetCell(j);

								if (cell != null) //若cell有值
								{
									//用cell.CellType判斷資料的型別
									//再依照欄位屬性，用StringCellValue、DateCellValue、NumericCellValue、DateCellValue取值
									switch (cell.CellType)
									{
										//字串型態欄位
										case NPOI.SS.UserModel.CellType.String:
											//設定dataRow第j欄位的值，cell以字串型態取值
											dataRow[j] = cell.StringCellValue;
											break;

										//數字型態欄位
										case NPOI.SS.UserModel.CellType.Numeric:

											if (HSSFDateUtil.IsCellDateFormatted(cell)) //日期格式
											{
												//設定dataRow第j欄位的值，cell以日期格式取值
												dataRow[j] = DateTime.FromOADate(cell.NumericCellValue).ToString("yyyy/MM/dd HH:mm");
											}
											else //非日期格式
											{
												//設定dataRow第j欄位的值，cell以數字型態取值
												dataRow[j] = cell.NumericCellValue;
											}
											break;

										//布林值
										case NPOI.SS.UserModel.CellType.Boolean:

											//設定dataRow第j欄位的值，cell以布林型態取值
											dataRow[j] = cell.BooleanCellValue;
											break;

										//空值
										case NPOI.SS.UserModel.CellType.Blank:

											dataRow[j] = "";
											break;

										// 預設
										default:

											dataRow[j] = cell.StringCellValue;
											break;
									}
								}
							}
							//DataTable加入dataRow
							dataTable.Rows.Add(dataRow);
						}
						catch (Exception ex)
						{
							//錯誤訊息
							throw new Exception("第 " + i + "列第" + column + "欄，資料格式有誤:\r\r" + ex.ToString());
						}
					}
				}
				catch (Exception ex)
				{
					ViewBag.Message = "匯入失敗";
					Console.Write(ex.Message);
				}
				finally
				{
					//釋放資源
					sheet = null;
					wb = null;
					stream.Dispose();
					stream.Close();
				}

				//dataTable跑回圈，insert資料至DB

				foreach (DataRow dataRow in dataTable.Rows)
				{
					Product product = new Product()
					{
						Index = dataRow["Index"].ToString(),
						GameId = int.Parse(dataRow["GameId"].ToString()),
						IsVirtual = bool.Parse(dataRow["IsVirtual"].ToString()),
						Price = int.Parse(dataRow["Price"].ToString()),
						GamePlatformId = int.Parse(dataRow["GamePlatformId"].ToString()),
						SystemRequire = dataRow["SystemRequire"].ToString(),
						ProductStatusId = int.Parse(dataRow["ProductStatusId"].ToString()),
						SaleDate = DateTime.Parse(dataRow["SaleDate"].ToString())
					};

					try
					{
						var currentUserAccount = User.Identity.Name;
						NPOIHelper products = new NPOIHelper();
						products.InsertProducts(product, currentUserAccount);
					}
					catch (Exception ex)
					{
						ViewBag.Message = "匯入失敗";
					}
				}
			}
			return View();
		}

	}
}