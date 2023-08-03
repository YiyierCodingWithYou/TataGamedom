using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence.Repositories;

public class StockInSheetRepository : GenericRepository<StockInSheet>, IStockInSheetRepository
{
    public StockInSheetRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }

    public async Task<bool> IsStockInSheetExist(int stockInSheetId)
    {
        return await _dbContext.StockInSheets.AnyAsync(s => s.Id == stockInSheetId);
    }
}
