using MediatR;

namespace TataGamedomWebAPI.Application.Features.Order.Commands.UpdateOrder;

public class UpdateOrderCommand : IRequest<Unit> 
{
    public int Id { get; set; }
    public int OrderStatusId { get; set; }
    public int? ShipmentStatusId { get; set; }
    public int PaymentStatusId { get; set; }
    public int ShipmemtMethodId { get; set; }
    public string? TrackingNum { get; set; }

}

