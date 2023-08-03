namespace TataGamedomWebAPI.Application.Features.OrderItem.Queries.GetOrderItemList;

public class OrderItemDto
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal ProductPrice { get; set; }

    public int InventoryItemId { get; set; }

}
