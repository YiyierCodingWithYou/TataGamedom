using MediatR;
using TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateMultipleOrderItems;

namespace TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateOrderItem;

public class CreateOrderItemCommand : IRequest<CreateOrderItemResponseDto>
{
    public int OrderId { get; set; }

    public decimal ProductPrice { get; set; }

    public int ProductId { get; set; }

}
