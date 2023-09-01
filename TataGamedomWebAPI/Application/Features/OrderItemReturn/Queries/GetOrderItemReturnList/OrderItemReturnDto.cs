using TataGamedomWebAPI.Application.Features.OrderItem.Queries.GetOrderItemList;

namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Queries.GetOrderItemReturnList;

public class OrderItemReturnDto
{
    public int Id { get; set; }

    public string? Index { get; set; }

    public int OrderItemId { get; set; }

    public string? Reason { get; set; }

    public DateTime IssuedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public bool IsRefunded { get; set; }

    public bool IsReturned { get; set; }

    public bool IsResellable { get; set; }

    public string? LinePayRefundTransactionId { get; set; }


    public required OrderItemDto OrderItem { get; set; }


}
