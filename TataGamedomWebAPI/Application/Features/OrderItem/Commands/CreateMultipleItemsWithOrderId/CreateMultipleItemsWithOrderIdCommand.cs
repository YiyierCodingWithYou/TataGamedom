using MediatR;
using TataGamedomWebAPI.Application.Features.Order.Commands.CreateOrder;
using TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateMultipleOrderItems;
using TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateOrderItem;

namespace TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateMultipleItemsWithOrderId;

public class CreateMultipleItemsWithOrderIdCommand : IRequest<List<CreateOrderItemResponseDto>>
{
    public required CreateOrderCommand CreateOrderCommand { get; set; }
    public required List<CreateOrderItemCommand> CreateOrderItemCommandList { get; set; }
}
