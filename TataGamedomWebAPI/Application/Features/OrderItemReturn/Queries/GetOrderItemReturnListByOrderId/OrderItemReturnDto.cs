namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Queries.GetOrderItemReturnListByOrderId;

public class OrderItemReturnDto
{
    public int Id { get; set; }

    public string Index { get; set; } = string.Empty;

    public int OrderItemId { get; set; }

    public string? Reason { get; set; }

    public DateTime IssuedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public bool IsRefunded { get; set; }

    public bool IsReturned { get; set; }

    public bool IsResellable { get; set; }

    public string? LinePayRefundTransactionId { get; set; }

}

