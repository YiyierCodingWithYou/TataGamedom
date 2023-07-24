using MediatR;

namespace TataGamedom_FrontEnd.Models.Infra.OrderInfra.Commands;

public record UpdateOrderCommand(
    int Id,
    int OrderStatusId,
    int ShipmentStatusId,
    int PaymentStatusId,
    int ShipmemtMethodId,
    string? TrackingNum) : IRequest<int>;   
