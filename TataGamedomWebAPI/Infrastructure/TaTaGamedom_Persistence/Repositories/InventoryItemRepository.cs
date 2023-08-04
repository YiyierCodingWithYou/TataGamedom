using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence.Repositories;

public class InventoryItemRepository : GenericRepository<InventoryItem>, IInventoryItemRepository
{
    public InventoryItemRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> IsInventoryItemExist(int inventoryItemId)
    {
        return await _dbContext.InventoryItems.AnyAsync(i => i.Id == inventoryItemId);
    }

    public async Task<bool> IsInventoryItemNotSold(int inventoryItemId)
    {
        return await _dbContext.OrderItems.AnyAsync(o => o.InventoryItemId == inventoryItemId) == false;
    }
}

