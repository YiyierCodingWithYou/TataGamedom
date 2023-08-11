using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Contracts.Persistence;

public interface IInventoryItemRepository : IGenericRepository<InventoryItem>
{
    Task<int> GetRemainingInventoryId(int productId);
    Task<int> GetRemainingInventoryQuantity(int productId);
    Task<bool> IsInventoryItemExist(int inventoryItemId);
    Task<bool> IsInventoryItemNotSold(int inventoryItemId);
}
