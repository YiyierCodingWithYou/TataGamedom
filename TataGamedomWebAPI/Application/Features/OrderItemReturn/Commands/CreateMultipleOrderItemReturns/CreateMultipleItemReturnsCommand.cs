using MediatR;
using TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateOrderItem;
using TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.CreateOrderItemReturn;
using TataGamedomWebAPI.Application.Features.OrderItemReturn.Queries.GetOrderItemReturnList;

namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.CreateMultipleOrderItemReturns;

public class CreateMultipleItemReturnsCommand : IRequest<List<OrderItemReturnDto>>
{
    public required List<CreateOrderItemReturnCommand> CreateOrderItemReturnCommandList { get; set; }
}
