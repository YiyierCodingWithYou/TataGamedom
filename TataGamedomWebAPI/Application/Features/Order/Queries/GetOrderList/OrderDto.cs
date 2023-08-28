namespace TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderList;

public class OrderDto
{
    public int Id { get; set; }

    public required string Index { get; set; }

    public int MemberId { get; set; }

    public int OrderStatusId { get; set; }

    public int ShipmentStatusId { get; set; }

    public int PaymentStatusId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public int ShipmentMethodId { get; set; }

    public string? RecipientName { get; set; }

    public required string ToAddress { get; set; }

    public DateTime? SentAt { get; set; }

    public DateTime? DeliveredAt { get; set; }

    public string? TrackingNum { get; set; }

}
