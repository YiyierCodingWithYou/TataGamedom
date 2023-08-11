using MediatR;
using TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateOrderItem;

namespace TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateMultipleOrderItems;

public class CreateMultipleOrderItemsCommand : IRequest<List<Models.EFModels.OrderItem>>
{
    public required List<CreateOrderItemCommand> CreateOrderItemCommandList{ get; set; }
}
