using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TataGamedom.Models.Dtos.StockInSheets;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Infra;
using TataGamedom.Models.Interfaces;

namespace TataGamedom.Models.Services
{
	public class StockInSheetService
	{
		private readonly IStockInSheetRepository _repo;
        public StockInSheetService(IStockInSheetRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<StockInSheetIndexDto> Search() => _repo.Search();

        public Result Create(StockInSheetDto dto) 
        {
			dto.Index = GetIndex(dto);
			_repo.Create(dto);
            return Result.Success();
        }

		private string GetIndex(StockInSheetDto dto) 
		{
			int maxId = _repo.GetMaxIdInDb();
			var indexGenerator = new IndexGenerator(maxId);
			return indexGenerator.GetStockInSheetIndex(dto);
		}
        public StockInSheetDto GetById(int? id) => _repo.GetById(id);
        
        public Result Update(StockInSheetDto dto) 
        {
            _repo.Update(dto);
            return Result.Success();
        }



		/// <summary>
		/// 取得庫存總數為0，且有設定自動下單的InventoryItem productId
		/// </summary>
		/// <returns></returns>
		private List<int> GetProductIdNeedAutoOrder() => _repo.GetProductIdNeedAutoOrder();

		/// <summary>
		/// 目前設定: 根據近一年下單頻率選擇Supplier
		/// </summary>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		private int GetSupplierIdSet(int? productId) => _repo.GetAutoOrderSupplierId(productId); 

	}
}