using MediatR;

namespace TataGamedom_FrontEnd.Models.Infra.OrderInfra.Commands;

public record UpdateOrderCommand(
    int Id,
    string Index,
    int MemberId,
    int OrderStatusId,
    int ShipmentStatusId,
    int PaymentStatusId,
    DateTime CreatedAt,
    DateTime? CompletedAt,
    int ShipmemtMethodId,
    string RecipientName,
    string ToAddress,
    DateTime? SentAt,
    DateTime? DeliveredAt,
    string? TrackingNum) : IRequest<int>;   
