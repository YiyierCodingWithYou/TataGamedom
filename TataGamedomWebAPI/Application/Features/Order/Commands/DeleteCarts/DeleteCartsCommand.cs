using MediatR;
namespace TataGamedomWebAPI.Application.Features.Order.Commands.DeleteCarts;

public class DeleteCartsCommand : IRequest<Unit>
{
    public int MemberId { get; set; }
}
