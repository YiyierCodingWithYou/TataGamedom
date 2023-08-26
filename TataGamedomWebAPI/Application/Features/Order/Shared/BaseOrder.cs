using TataGamedomWebAPI.Infrastructure;

namespace TataGamedomWebAPI.Application.Features.Order.Shared;

public abstract class BaseOrder
{
    public int OrderStatusId { get; set; } = (int)OrderStatus.Processing;
    public int? ShipmentStatusId { get; set; } = (int)ShipmentStatus.PreparingStock;
    public int PaymentStatusId { get; set; } = (int)PaymentStatus.Unpaid;
    public int? ShipmemtMethodId { get; set; }
    public string? RecipientName { get; set; }
    public int? ShippingFee { get; set; }
    public string ReceiverEmail { get; set; } = string.Empty;
    public string ReceiverCellPhone { get; set; } = string.Empty;
}
