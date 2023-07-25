using MediatR;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Infrastructure.OrderInfrastructure.Commands;
public record CreateOrderCommand(
    int MemberId,
    int OrderStatusId,
    int ShipmentStatusId,
    int PaymentStatusId,
    int ShipmemtMethodId,
    string RecipientName,
    string ToAddress) : IRequest<Order>;

