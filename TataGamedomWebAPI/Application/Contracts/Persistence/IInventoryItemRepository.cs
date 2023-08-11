using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Contracts.Persistence;

public interface IInventoryItemRepository : IGenericRepository<InventoryItem>
{
    Task<int> GetMaxId();
    Task<List<int>> GetRemaingItemIdListByProductId(int productId);
    Task<int> GetRemainingInventoryId(int productId);
    Task<int> GetRemainingInventoryId(int productId, HashSet<int> allocatedInventoryIds);
    Task<int> GetRemainingInventoryQuantity(int productId);
    Task<HashSet<int>> GetSoldOutIdList();
    Task<bool> IsInventoryItemExist(int inventoryItemId);
    Task<bool> IsInventoryItemNotSoldOut(int inventoryItemId);
}
