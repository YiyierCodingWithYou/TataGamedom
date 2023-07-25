using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TataGamedom.Models.Dtos.Games;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Infra;
using TataGamedom.Models.Infra.DapperRepositories;
using TataGamedom.Models.Interfaces;
using TataGamedom.Models.ViewModels.Games;

namespace TataGamedom.Models.Services
{
	public class GameService
	{
		private AppDbContext db = new AppDbContext();
		private IGameRepository _repo;
		public GameService(IGameRepository repo)
		{
			_repo = repo;
		}

		public IEnumerable<GameIndexVM> Search()
		{
			return _repo.Search()
				.Select(dto => new GameIndexVM
				{
					Id = dto.Id,
					ChiName = dto.ChiName,
					ModifiedBackendMemberName = dto.ModifiedBackendMemberName,
					ModifiedTime = dto.ModifiedTime,
					GameCoverImg = dto.GameCoverImg,
					IsRestrict = dto.IsRestrict,
					CreatedBackendMemberName = dto.CreatedBackendMemberName,
					CreatedTime = dto.CreatedTime,
				});
		}

		public GameEditVM GetGameEditVM(int id)
		{
			var game = _repo.GetGameById(id);
			if (game == null)
			{
				return null;
			}
			var classification = _repo.GetGameClassificationGames(id);
			var classificationList = _repo.GetGameClassifications();
			var backendMember = _repo.GetBackendMemberName(game.ModifiedBackendMemberId);
			return new GameEditVM
			{
				Id = game.Id,
				GameClassification = classificationList,
				SelectedGameClassification = classification != null ? classification.Select(c => c.GameClassificationId).ToList() : new List<int>(),
				ChiName = game.ChiName,
				EngName = game.EngName,
				Description = game.Description,
				IsRestrict = game.IsRestrict,
				ModifiedTime = game.ModifiedTime,
				ModifiedBackendMemberName = backendMember != null ? backendMember.Name : null,
				ModifiedBackendMemberId = game.ModifiedBackendMemberId
			};
		}

		public Result UpdateGame(GameEditVM vm)
		{
			var game = _repo.GetGameById(vm.Id);
			if (game == null)
			{
				return Result.Fail("查無該筆遊戲");
			}

			if (_repo.IsDuplicateChineseName(vm.Id, vm.ChiName))
			{
				return Result.Fail("已存在此中文名稱之遊戲");
			}

			if (_repo.IsDuplicateEnglishName(vm.Id, vm.EngName))
			{
				return Result.Fail("已存在此英文名稱之遊戲");
			}

			var dto = vm.ToDto();
			dto.ModifiedTime = DateTime.Now;
			var updateResult = _repo.UpddateGame(dto);
			if (!updateResult)
			{
				return Result.Fail("更新失敗");
			}

			return Result.Success();
		}

		public Result CreateGame(GameCreateVM vm)
		{
			var dto = vm.ToDto();
			var game = _repo.GetGameByName(dto.ChiName, dto.EngName);
			if (game != null)
			{
				if (dto.ChiName == game.ChiName || dto.EngName == game.EngName)
				{
					return Result.Fail("該遊戲已存在！");
				}
			}

			var createResult = _repo.Create(dto);
			if (!createResult)
			{
				return Result.Fail("新增遊戲失敗！");
			}
			return Result.Success();
		}

		public List<GameClassificationsCode> GetGameClassifications()
		{
			return _repo.GetGameClassifications();
		}

		public GameEditCoverImgVM GetGameCover(int id)
		{
			var game = _repo.GetGameById(id);
			if (game == null) { return null; }
			return new GameEditCoverImgVM
			{
				Id = game.Id,
				GameCoverImg = game.GameCoverImg
			};
		}
		public Result EditGameCover(GameEditCoverImgVM vm)
		{
			var editCover = vm.ToDto();
			var editCoverResult = _repo.EditGameCover(editCover);
			if (!editCoverResult)
			{
				return Result.Fail("遊戲封面更新失敗！");
			}
			return Result.Success();
		}

		public Result CreateBoard(GameCreateVM vm)
		{
			var result = _repo.GetGameByName(vm.ChiName, vm.EngName);
			if (result == null)
			{
				return Result.Fail("討論版新增失敗");
			}
			var createBoard = _repo.CreateBoard(result);
			if (!createBoard)
			{
				return Result.Fail("討論版新增失敗");
			}
			return Result.Success();
		}

		public Result CreateClassification(GameCreateVM vm)
		{
			var result = _repo.GetGameByName(vm.ChiName, vm.EngName);
			if (result == null)
			{
				return Result.Fail("遊戲類別新增失敗");
			}
			foreach (var classificationId in vm.SelectedGameClassification)
			{
				var createClassification = _repo.CreateClassification(result, classificationId);
				if (!createClassification)
				{
					return Result.Fail("遊戲類別新增失敗");
				}
			}
			return Result.Success();
		}

		public Result UpdateClassification(GameEditVM vm)
		{
			var games = _repo.GetGameClassificationGames(vm.Id);
			if (games != null)
			{
				var deleteResult = _repo.DeleteGameClassificationGames(vm.Id);
				if (!deleteResult)
				{
					return Result.Fail("更新失敗");
				}
			}
			return Result.Success();
		}

		public Result CreateClassification(GameEditVM vm)
		{
			var result = _repo.GetGameByName(vm.ChiName, vm.EngName);
			if (result == null)
			{
				return Result.Fail("遊戲類別新增失敗");
			}
			foreach (var classificationId in vm.SelectedGameClassification)
			{
				var createClassification = _repo.CreateClassification(result, classificationId);
				if (!createClassification)
				{
					return Result.Fail("遊戲類別新增失敗");
				}
			}
			return Result.Success();
		}

		public GameAddProductVM AddProduct(int id)
		{
			var game = _repo.GetGameById(id);
			if (game == null) { return null; }
			return new GameAddProductVM
			{
				//Id = game.Id,
				GameId = game.Id,
				GameChiName = game.ChiName,
				GameEngName = game.EngName,
				Description = game.Description,
				Status = "待上架"
			};
		}

		public Result CreateProduct(GameAddProductVM vm)
		{
			var gameProduct = db.Products.FirstOrDefault(p => p.GameId == vm.GameId && p.GamePlatformId == vm.Platform);
			if (gameProduct != null)
			{
				return Result.Fail("該商品已存在！");
			}
			else
			{
				string index = "";
				switch (vm.Platform)
				{
					case 1:
						index = "PC";
						break;
					case 2:
						index = "PS";
						break;
					case 3:
						index = "SW";
						break;
				}
				var product = new Product
				{
					GameId = vm.GameId,
					Index = (index + vm.GameId.ToString() + vm.Platform.ToString()),//自訂編號：平台Name(0,2) + 遊戲ID + 平台ID
					GamePlatformId = vm.Platform,
					IsVirtual = vm.IsVirtual,
					Price = vm.Price,
					SystemRequire = vm.SystemRequire,
					SaleDate = vm.SaleDate,
					ProductStatusId = 1,
					CreatedBackendMemberId = vm.CreateBackendMemberId,
					CreatedTime = DateTime.Now,
					ModifiedBackendMemberId = null,
					ModifiedTime = null
				};
				var result = _repo.CreateProduct(product);
				if (!result)
				{
					return Result.Fail("商品新增失敗");
				}
			}
			return Result.Success();
		}

		public Result CreateProductImg(GameAddProductVM vm)
		{
			var gameProduct = db.Products.FirstOrDefault(p => p.GameId == vm.GameId && p.GamePlatformId == vm.Platform);
			int productId = 0;
			if (gameProduct != null)
			{
				productId = gameProduct.Id;
			}
			foreach (var item in vm.ProductImg)
			{
				var productImages = new ProductImage
				{
					ProductId = productId,
					Image = item
				};
				var createImgResult = _repo.CreateProductImg(productImages);
				if (!createImgResult)
				{
					return Result.Fail("商品圖片新增失敗");
				}
			}
			return Result.Success();
		}

		public Result Upload(HttpPostedFileBase file, string currentUserAccount)
		{

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
					if (file.FileName.ToUpper().EndsWith("XLSX"))
						wb = new XSSFWorkbook(stream); // excel版本(.xlsx)
					else
						wb = new HSSFWorkbook(stream); // excel版本(.xls)

					sheet = wb.GetSheetAt(0);

					headerRow = sheet.GetRow(0);

					cellCount = headerRow.LastCellNum;

					try
					{
						for (int i = headerRow.FirstCellNum; i < cellCount; i++)
						{
							dataTable.Columns.Add(new DataColumn(headerRow.GetCell(i).StringCellValue));
						}
					}
					catch (Exception ex)
					{
						return Result.Fail("匯入失敗：" + ex.Message);
					}

					int column = 1; //計算每一列讀到第幾個欄位

					for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
					{
						IRow row = sheet.GetRow(i);

						if (string.IsNullOrEmpty(row.Cells[0].ToString().Trim()))
						{
							break;
						}

						DataRow dataRow = dataTable.NewRow();
						ICell cell;

						try
						{
							for (int j = row.FirstCellNum; j < cellCount; j++)
							{
								column = j + 1;

								cell = row.GetCell(j);

								if (cell != null) //若cell有值
								{
									switch (cell.CellType)
									{
										case NPOI.SS.UserModel.CellType.String:
											dataRow[j] = cell.StringCellValue;
											break;

										case NPOI.SS.UserModel.CellType.Numeric:

											if (HSSFDateUtil.IsCellDateFormatted(cell)) //日期格式
											{
												dataRow[j] = DateTime.FromOADate(cell.NumericCellValue).ToString("yyyy/MM/dd HH:mm");
											}
											else //非日期格式
											{
												dataRow[j] = cell.NumericCellValue;
											}
											break;

										case NPOI.SS.UserModel.CellType.Boolean:

											dataRow[j] = cell.BooleanCellValue;
											break;

										case NPOI.SS.UserModel.CellType.Blank:

											dataRow[j] = null;
											break;

										default:

											dataRow[j] = cell.StringCellValue;
											break;
									}
								}
							}
							dataTable.Rows.Add(dataRow);
						}
						catch (Exception ex)
						{
							return Result.Fail("第 " + i + "列第" + column + "欄，資料格式有誤:\r\r" + ex.ToString());
						}
					}
				}
				catch (Exception ex)
				{
					return Result.Fail("匯入失敗：" + ex.Message);
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
				try
				{
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
							NPOIHelper games = new NPOIHelper();
							games.InsertGames(game, currentUserAccount);

							NPOIHelper boards = new NPOIHelper();
							boards.InsertBoards(board, currentUserAccount);
						}
						catch (Exception ex)
						{
							return Result.Fail("匯入失敗：" + ex.Message);
						}
					}
				}
				catch (Exception ex)
				{
					return Result.Fail("匯入失敗：" + ex.Message);
				}
				return Result.Success();
			}
			return Result.Fail("未選擇上傳檔案");
		}
	}
}