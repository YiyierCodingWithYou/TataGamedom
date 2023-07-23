using MediatR;

namespace TataGamedom_FrontEnd.Models.Infra.Order.Create;

public record CreateOrderCommand(
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
    string? TrackingNum) : IRequest
{
}

