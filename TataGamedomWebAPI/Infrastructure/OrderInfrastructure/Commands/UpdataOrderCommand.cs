using MediatR;

namespace TataGamedomWebAPI.Infrastructure.OrderInfrastructure.Commands;

public record UpdateOrderCommand(
    int Id,
    int OrderStatusId,
    int ShipmentStatusId,
    int PaymentStatusId,
    int ShipmemtMethodId,
    string? TrackingNum) : IRequest<int>;