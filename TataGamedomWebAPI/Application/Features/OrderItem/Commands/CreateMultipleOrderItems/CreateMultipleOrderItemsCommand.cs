using MediatR;
using TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateOrderItem;

namespace TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateMultipleOrderItems;

public class CreateMultipleOrderItemsCommand : IRequest<List<CreateOrderItemResponseDto>>
{
    public required List<CreateOrderItemCommand> CreateOrderItemCommandList{ get; set; }
}
