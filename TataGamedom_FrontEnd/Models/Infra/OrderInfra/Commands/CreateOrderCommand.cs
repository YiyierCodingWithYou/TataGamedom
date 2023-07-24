using MediatR;
using TataGamedom_FrontEnd.Models.EFModels;

namespace TataGamedom_FrontEnd.Models.Infra.OrderInfra.Commands;

public record CreateOrderCommand(
    int MemberId,
    int OrderStatusId,
    int ShipmentStatusId,
    int PaymentStatusId,
    int ShipmemtMethodId,
    string RecipientName,
    string ToAddress) : IRequest<Order>;