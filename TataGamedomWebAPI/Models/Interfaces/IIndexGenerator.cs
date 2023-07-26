using TataGamedomWebAPI.Models.Dtos;

namespace TataGamedomWebAPI.Models.Interfaces;

//Orders "命名規則: CreatedAt+ ShipmentMethodId + MemberId + Id"
// e.g.             20230630         1             2        1
//				=>20230630121
//OrderItemReturns: "命名規則: IssuedAt + OrderItemsIndex + Id"
//InventoryItems:"Display(Name='SKU') , 命名規則: 1/0(Isvirtual) + ProductIndex + Id"
//StockInSheets : "命名規則: OrderRequestDate + InventoryItemSKU + Id"
//Product: ?

public interface IIndexGenerator
{
    string GetOrderIndex(OrderCreateDto dto);
}
