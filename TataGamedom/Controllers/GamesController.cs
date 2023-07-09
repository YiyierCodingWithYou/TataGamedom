using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Infra;
using TataGamedom.Models.Infra.DapperRepositories;
using TataGamedom.Models.Interfaces;
using TataGamedom.Models.Services;
using TataGamedom.Models.ViewModels.Games;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data.Entity;
using System.Data;
using System.IO;

namespace TataGamedom.Controllers
{
	public class GamesController : Controller
	{
		private AppDbContext db = new AppDbContext();
		// GET: Games
		[Authorize]
		public ActionResult Index()
		{
			IEnumerable<GameIndexVM> games = GetGames();
			return View(games);
		}

		private IEnumerable<GameIndexVM> GetGames()
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			return service.Search();
		}
		[Authorize]
		public ActionResult Create()
		{
			var gameClassifications = GetGameClassifications();
			GameCreateVM model = new GameCreateVM
			{
				GameClassification = gameClassifications
			};
			return View(model);
		}

		private List<GameClassificationsCode> GetGameClassifications()
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			return service.GetGameClassifications();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(GameCreateVM vm, HttpPostedFileBase GameCoverImg)
		{
			var currentUserAccount = User.Identity.Name;
			var memberInDb = db.BackendMembers.FirstOrDefault(m => m.Account == currentUserAccount);
			var savedFileName = SaveFile(GameCoverImg);

			vm.GameCoverImg = savedFileName;
			vm.CreatedBackendMemberId = memberInDb.Id;
			ViewBag.GameClassification = GetGameClassifications();

			if (ModelState.IsValid == false)
			{
				vm.GameClassification = GetGameClassifications();
				return View(vm);
			}
			Result createResult = CreateGame(vm);
			if (createResult.IsSuccess)
			{
				//新增遊戲類別
				CreateGameClassification(vm);
				//新增遊戲討論版
				CreateGameBoard(vm);

				return RedirectToAction("Index");
			}
			ModelState.AddModelError(string.Empty, createResult.ErrorMessage);
			vm.GameClassification = GetGameClassifications();
			return View(vm);
		}

		private void CreateGameBoard(GameCreateVM vm)
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			service.CreateBoard(vm.ChiName);
		}

		private void CreateGameClassification(GameCreateVM vm)
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			service.CreateClassification(vm);
		}

		private Result CreateGame(GameCreateVM vm)
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			return service.CreateGame(vm);
		}

		private string SaveFile(HttpPostedFileBase file1)
		{
			var path = Server.MapPath("~/Files/Uploads");

			var helper = new UploadFileHelper(new GuidRenameProvider(),
											new RequiredValidator(), // 必需上傳檔案
											new ImageValidator(), // 必需是圖片檔案
											new FileSizeValidator(1920 * 1920) // 必需小於1MB		
											);
			var fileName = helper.SaveFile(file1, path);

			return fileName ?? string.Empty;
		}
		[Authorize]
		public ActionResult Edit(int id)
		{
			var gameClassifications = GetGameClassifications();
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			var game = service.GetGameById(id);
			GameEditVM model = new GameEditVM
			{
				GameClassification = gameClassifications,
				SelectedGameClassification = game.SelectedGameClassification,
				Id = game.Id,
				ChiName = game.ChiName,
				EngName = game.EngName,
				Description = game.Description,
				IsRestrict = game.IsRestrict,
				ModifiedTime = game.ModifiedTime,
				ModifiedBackendMemberName = game.ModifiedBackendMemberName,
				ModifiedBackendMemberId = game.ModifiedBackendMemberId
			};
			return View(model);
		}
		[HttpPost]
		public ActionResult Edit(GameEditVM vm)
		{
			if (ModelState.IsValid)
			{
				var currentUserAccount = User.Identity.Name;
				var memberInDb = db.BackendMembers.FirstOrDefault(m => m.Account == currentUserAccount);

				List<int> selectedGameClassifications = vm.SelectedGameClassification;
				if (selectedGameClassifications.Count > 2)
				{
					ModelState.AddModelError("SelectedGameClassification", "最多只能選擇兩個遊戲分類！");
					vm.GameClassification = GetGameClassifications();
					return View(vm);
				}
				vm.ModifiedBackendMemberId = memberInDb.Id;
				Result editResult = UpdateGames(vm);
				if (editResult.IsSuccess)
				{
					UpdateGameClassification(vm);
					CreateGameClassification(vm);
					return RedirectToAction("Index");
				}
				ModelState.AddModelError(string.Empty, editResult.ErrorMessage);		
				vm.GameClassification = GetGameClassifications();
				return View(vm);
			}
			vm.GameClassification = GetGameClassifications();
			return View(vm);
		}
		private void CreateGameClassification(GameEditVM vm)
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			service.CreateClassification(vm);
		}
		private void UpdateGameClassification(GameEditVM vm)
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			service.UpdateClassification(vm);
		}

		private Result UpdateGames(GameEditVM vm)
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			return service.UpdateGame(vm);
		}
		[Authorize]
		public ActionResult EditGameCover(int id)
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			var game = service.GetGameById2(id);
			return View(game);
		}

		[HttpPost]
		public ActionResult EditGameCover(GameEditCoverImgVM vm, HttpPostedFileBase file1)
		{
			if (file1 != null) // 檢查是否選擇了新的檔案
			{
				var savedFileName = SaveFile(file1);
				if (savedFileName == null)
				{
					ModelState.AddModelError("CoverImg", "請選擇檔案");
					return View(vm);
				}
				vm.GameCoverImg = savedFileName;
			}
			if (ModelState.IsValid)
			{
				var currentUserAccount = User.Identity.Name;
				var memberInDb = db.BackendMembers.FirstOrDefault(m => m.Account == currentUserAccount);
				vm.ModifiedBackendMemberId = memberInDb.Id;
				IGameRepository repo = new GameDapperRepository();
				GameService service = new GameService(repo);
				service.EditGameCover(vm);
				return RedirectToAction("Index");
			}
			return View(vm);
		}
		[Authorize]
		public ActionResult AddProduct(int id)
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			var game = service.GetGameByIdForAddProduct(id);
			var platforms = db.GamePlatformsCodes.Where(code => !code.Products.Any(p => p.GameId == id));
			ViewBag.Platform = new SelectList(platforms, "Id", "Name");
			ViewBag.PlatformOptionsCount = platforms.Count();

			return View(game);
		}
		[HttpPost]
		public ActionResult AddProduct(GameAddProductVM vm, HttpPostedFileBase[] files)
		{
			var currentUserAccount = User.Identity.Name;
			var memberInDb = db.BackendMembers.FirstOrDefault(m => m.Account == currentUserAccount);
			vm.CreateBackendMemberId = memberInDb.Id;

			if (files != null && files.Length > 0)
			{
				List<string> savedFileNames = new List<string>();

				foreach (var file in files)
				{
					var savedFileName = SaveFile(file);
					if (savedFileName != null)
					{
						savedFileNames.Add(savedFileName);
					}
				}
				vm.ProductImg = savedFileNames;
			}
			if (!ModelState.IsValid)
			{
				IGameRepository repo = new GameDapperRepository();
				GameService service = new GameService(repo);
				var game = service.GetGameByIdForAddProduct(vm.Id);
				ViewBag.Platform = new SelectList(db.GamePlatformsCodes.Where(code => !code.Products.Any(p => p.GameId == vm.Id)), "Id", "Name");
				return View(vm);
			}
			//新增商品
			var productResult = CreateProduct(vm);
			if (productResult.IsFail)
			{
				ModelState.AddModelError("", "該商品已存在！");
				ViewBag.Platform = new SelectList(db.GamePlatformsCodes, "Id", "Name");
				return View(vm);
			}
			//新增商品圖片
			var imgResult = CreateProductImg(vm);
			if (imgResult.IsFail)
			{
				ModelState.AddModelError("", "新增商品圖片失敗！");
				return View(vm);
			}
			return RedirectToAction("Index");
		}

		private Result CreateProductImg(GameAddProductVM vm)
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			return service.CreateProductImg(vm);
		}

		private Result CreateProduct(GameAddProductVM vm)
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			return service.CreateProduct(vm);
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

											dataRow[j] = null;
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
					Game game = new Game()
					{
						ChiName = dataRow["ChiName"].ToString(),
						EngName = dataRow["EngName"].ToString(),
						Description = dataRow["Description"].ToString(),
						IsRestrict = bool.Parse(dataRow["IsRestrict"].ToString()),
						GameCoverImg = dataRow["GameCoverImg"].ToString(),
					};

					Board board = new Board()
					{
						Name = dataRow["ChiName"].ToString(),
						GameId = int.Parse(dataRow["GameId"].ToString()),
						BoardAbout = dataRow["Description"].ToString(),
						BoardHeaderCoverImg = dataRow["GameCoverImg"].ToString()
					};

					try
					{
						var currentUserAccount = User.Identity.Name;
						NPOIHelper games = new NPOIHelper();
						games.InsertGames(game, currentUserAccount);

						NPOIHelper boards = new NPOIHelper();
						boards.InsertBoards(board, currentUserAccount);
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