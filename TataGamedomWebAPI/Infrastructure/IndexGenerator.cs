using Humanizer;
using System;
using System.Security.Cryptography;
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
    public string GetOrderIndex(Order order, int maxOrderId)
    {
        return string.Concat(order.CreatedAt.ToString("yyyyMMdd"), order.ShipmemtMethodId, order.MemberId, maxOrderId + 1);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orderItem"></param>
    /// <param name="maxOrderItemId"></param>
    /// <returns></returns>
    public string GetOrderItemIndex(OrderItem orderItem, int maxOrderItemId)
    {
        return string.Concat(orderItem.ProductId, orderItem.InventoryItemId, maxOrderItemId + 1);
    }

    /// <summary>
    /// "命名規則: IssuedAt + 對應到的訂單Index + Id"
    /// </summary>
    public string GetOrderItemReturnIndex(OrderItemReturn orderItemReturn, string orderIndex, int maxOrderItemReturnId)
    {
        return string.Concat(orderItemReturn.IssuedAt.ToString("yyyyMMdd"),Guid.NewGuid()); //todo
    }


    /// <summary>
    /// "Display(Name='SKU') , 命名規則: ProductIndex + StockInSheetIndex + Id"
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public string GetSKU(InventoryItem inventoryItemToBeCreated, int maxInventoryItemId)
    {
        return string.Concat(inventoryItemToBeCreated.Product.Index, inventoryItemToBeCreated.StockInSheet.Index, maxInventoryItemId + 1);
    }


}