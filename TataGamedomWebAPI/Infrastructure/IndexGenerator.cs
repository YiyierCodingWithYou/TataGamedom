using System;
using TataGamedomWebAPI.Models.EFModels;
using TataGamedomWebAPI.Models.Interfaces;

namespace TataGamedom.Infrastructure;

public class IndexGenerator : IIndexGenerator
{
    /// <summary>
    /// "命名規則: CreatedAt+ ShipmentMethodId + MemberId + Id"
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    public string GetOrderIndex(Order order,int maxOrderId) 
        => string.Concat(order.CreatedAt.ToString("yyyyMMdd"), order.ShipmemtMethodId, order.MemberId, maxOrderId + 1);

    public string GetOrderItemIndex(OrderItem orderItem, int maxOrderItemId)
        => string.Concat(orderItem.ProductId, orderItem.InventoryItemId, maxOrderItemId + 1);

    /// <summary>
    /// "命名規則: IssuedAt + 對應到的訂單Index + Id"
    /// </summary>
    public string GetOrderItemReturnIndex(OrderItemReturn orderItemReturn, string orderIndex, int maxOrderId)
        => string.Concat(orderItemReturn.IssuedAt.ToString("yyyyMMdd"), orderIndex, maxOrderId + 1);

}