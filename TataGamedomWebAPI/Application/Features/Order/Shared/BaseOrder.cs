namespace TataGamedomWebAPI.Application.Features.Order.Shared;

public abstract class BaseOrder
{
    public int OrderStatusId { get; set; } = 1;
    public int? ShipmentStatusId { get; set; }
    public int PaymentStatusId { get; set; } = 1;
    public int? ShipmemtMethodId { get; set; }
    public string? RecipientName { get; set; }
}
