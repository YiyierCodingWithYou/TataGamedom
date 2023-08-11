using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Features.InventoryItem.Queries.GetRemainingInventoryDetails;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence.Repositories;

public class InventoryItemRepository : GenericRepository<InventoryItem>, IInventoryItemRepository
{
    public InventoryItemRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<int> GetRemainingInventoryId(int productId)
    {
        var inventoryItemIdSoldOutList = await GetSoldOutIdList();

        return await _dbContext.InventoryItems
            .AsNoTracking()
            .Where(i => i.ProductId == productId && inventoryItemIdSoldOutList.Contains(i.Id) == false)
            .Select(i => i.Id)
            .FirstOrDefaultAsync();
    }

    public async Task<int> GetRemainingInventoryId(int productId, HashSet<int> soldOutIds)
    {
        return await _dbContext.InventoryItems
            .AsNoTracking()
            .Where(i => i.ProductId == productId && soldOutIds.Contains(i.Id) == false)
            .Select(i => i.Id)
            .FirstOrDefaultAsync();
    }


    public async Task<int> GetRemainingInventoryQuantity(int productId)
    {
        int inventoryItems = await _dbContext.InventoryItems
            .AsNoTracking()
            .Where(i => i.ProductId == productId)
            .CountAsync();

        int inventoryQuantitySoldOut = await _dbContext.OrderItems
            .AsNoTracking()
            .Where(o => o.ProductId == productId)
            .CountAsync();

        int remainingInventoryQuantity = inventoryItems - inventoryQuantitySoldOut;

        return remainingInventoryQuantity < 0? 0 : remainingInventoryQuantity;
    }

    public async Task<HashSet<int>> GetSoldOutIdList()
    {
        var soldOutIds = await _dbContext.OrderItems
            .AsNoTracking()
            .Select(oi => oi.InventoryItemId)
            .ToListAsync();

        return new HashSet<int>(soldOutIds);
    }

    public async Task<int> GetMaxId()
    {
        return await _dbContext.InventoryItems.MaxAsync(i => i.Id);
    }


    public async Task<bool> IsInventoryItemExist(int inventoryItemId)
    {
        return await _dbContext.InventoryItems.AnyAsync(i => i.Id == inventoryItemId);
    }

    public async Task<bool> IsInventoryItemNotSoldOut(int inventoryItemId)
    {
        return await _dbContext.OrderItems.AnyAsync(o => o.InventoryItemId == inventoryItemId) == false;
    }

}

