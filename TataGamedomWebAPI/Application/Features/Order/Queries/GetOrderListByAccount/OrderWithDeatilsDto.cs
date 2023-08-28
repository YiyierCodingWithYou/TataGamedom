namespace TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderListByAccount;

public class OrderWithDeatilsDto
{
    public int Id { get; set; }
    public required List<string> GameChiName { get; set; }

    public required List<bool> ProductIsVirtual { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? SentAt { get; set; }

    public DateTime? DeliveredAt { get; set; }

    public decimal? Total { get; set; }

    public required string OrderStatusCodeName { get; set; }

    public required string OrderIndex { get; set; }

    public DateTime? OrderCompletedAt { get; set; }

    public string? OrderShipmentMethod { get; set; } = string.Empty;

    public string? OrderRecipientName { get; set; } = string.Empty;

    public string? ContactEmails { get; set; } = string.Empty;

    public string? ToAddress { get; set; } = string.Empty;
}
