using MediatR;
using TataGamedomWebAPI.Models.Dtos;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Infrastructure.OrderInfrastructure.Commands;
public record CreateOrderCommand(
    int MemberId,
    string? RecipientName,
    string? ToAddress,
    int OrderStatusId = 1,
    int ShipmentStatusId = 1,
    int PaymentStatusId = 1,
    int ShipmemtMethodId = 1) : IRequest<Order>;

