using TataGamedomWebAPI.Application.Features.OrderItem.Queries.GetOrderItemList;

namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Queries.GetOrderItemReturnDetails;

public class OrderItemReturnDetailsDto
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public int OrderItemId { get; set; }

    public string Reason { get; set; } = null!;

    public DateTime IssuedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public bool IsRefunded { get; set; }

    public bool IsReturned { get; set; }

    public bool IsResellable { get; set; }

    public required OrderItemDto OrderItem { get; set; }

}
