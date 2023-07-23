using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Infra;
using TataGamedom.Models.Interfaces;
using TataGamedom.Models.ViewModels.Products;

namespace TataGamedom.Models.Services
{
	public class ProductService
	{
		private AppDbContext db = new AppDbContext();

		private IProductRepository _repo;
		public ProductService(IProductRepository repo)
		{
			_repo = repo;
		}

		public IEnumerable<ProductIndexVM> Get()
		{
			return _repo.Get();
		}
		public ProductEditVM Get(int id)
		{

			var product = _repo.GetGameById(id);
			if (product == null) { return null; }
			return product;
		}

		public Result Edit(ProductEditVM vm)
		{
			//抓修改前的資料
			var productOriginal = _repo.GetGameById(vm.Id);
			//抓是否有VM欲修改成的資料
			var product = _repo.GetGameByGameIdAndGPId(vm);
			if (product != null && productOriginal.GamePlatform != product.GamePlatformId)
			{
				return Result.Fail("該遊戲已存在此平台商品！"); //已經從controller擋掉該遊戲已存在的其他平台，基本上不會進這條
			}
			else
			{
				string index = "";
				switch (vm.GamePlatform)
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
				var update = new ProductEditVM
				{
					Id = vm.Id,
					Index = (index + vm.GameId.ToString() + vm.GamePlatform.ToString()),
					GamePlatform = vm.GamePlatform,
					IsVirtual = vm.IsVirtual,
					Price = vm.Price,
					ProductStatus = vm.ProductStatus,
					SystemRequire = vm.SystemRequire,
					SaleDate = vm.SaleDate,
					ModifiedBackendMemberId = vm.ModifiedBackendMemberId,
					ModifiedTime = DateTime.Now
				};
				var updateResult = _repo.Update(update);
				if (!updateResult)
				{
					return Result.Fail("商品編輯失敗！");
				}
			}
			return Result.Success();
		}

		public List<ProductEditImgVM> GetImgs(int id)
		{
			var result = _repo.GetImgs(id);
			return result;
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
					sheet = null;
					wb = null;
					stream.Dispose();
					stream.Close();
				}
				try
				{
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
							NPOIHelper producs = new NPOIHelper();
							producs.InsertProducts(product, currentUserAccount);

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
			}
			return Result.Success();
		}
	}
}