using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Contracts.Persistence;

public interface IStockInSheetRepository : IGenericRepository<StockInSheet>
{
    Task<bool> IsStockInSheetExist(int stockInSheetId);
}
