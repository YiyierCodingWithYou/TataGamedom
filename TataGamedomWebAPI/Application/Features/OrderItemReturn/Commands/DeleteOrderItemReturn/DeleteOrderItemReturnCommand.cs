using MediatR;

namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.DeleteOrderItemReturn;

public class DeleteOrderItemReturnCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
