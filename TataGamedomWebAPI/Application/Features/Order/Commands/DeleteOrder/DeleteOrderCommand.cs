using MediatR;
namespace TataGamedomWebAPI.Application.Features.Order.Commands.DeleteOrder;

public class DeleteOrderCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
