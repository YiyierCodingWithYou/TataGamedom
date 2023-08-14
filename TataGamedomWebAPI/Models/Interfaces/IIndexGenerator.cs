using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Models.Interfaces;

public interface IIndexGenerator
{
    string GetOrderIndex(Order order, int maxOrderId);

    string GetOrderItemIndex(OrderItem orderItem, int maxOrderItemId);

    string GetOrderItemReturnIndex(OrderItemReturn orderItemReturn, string orderIndex, int maxOrderItemReturnId);

    string GetSKU(InventoryItem inventoryItemToBeCreated, int maxInventoryItemId);
}
