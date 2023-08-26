namespace TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderDetails;

public class OrderDetailsDto 
{
    public int Id { get; set; }

    public required string Index { get; set; }

    public int MemberId { get; set; }

    public int OrderStatusId { get; set; }

    public int ShipmentStatusId { get; set; }

    public int PaymentStatusId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public int ShipmemtMethodId { get; set; }

    public string? RecipientName { get; set; }

    public required string ToAddress { get; set; }

    public string? ReceiverEmail { get; set; }

    public decimal? ShippingFee { get; set; }

    public string? ReceiverCellPhone { get; set; }

    public DateTime? SentAt { get; set; }

    public DateTime? DeliveredAt { get; set; }

    public string? TrackingNum { get; set; }
}

