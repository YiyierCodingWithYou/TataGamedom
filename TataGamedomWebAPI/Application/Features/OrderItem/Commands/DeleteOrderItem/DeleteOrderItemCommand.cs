using MediatR;

namespace TataGamedomWebAPI.Application.Features.OrderItem.Commands.DeleteOrderItem;

public class DeleteOrderItemCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
