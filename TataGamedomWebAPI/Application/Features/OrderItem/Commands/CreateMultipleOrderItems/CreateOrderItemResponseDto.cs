namespace TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateMultipleOrderItems;

public class CreateOrderItemResponseDto
{
    public int Id { get; set; }

    public string? Index { get; set; }

    public required string OrderIndex { get; set; }
    
    public int OrderId { get; set; }

    public int? ProductId { get; set; }

    public decimal ProductPrice { get; set; }

    public int InventoryItemId { get; set; }
}
