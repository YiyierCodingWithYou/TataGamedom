using MediatR;

namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.UpdateOrderItemReturn;

public class UpdateOrderItemReturnCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string? Reason { get; set; }

    public DateTime? CompletedAt { get; set; }

    public bool IsRefunded { get; set; } 

    public bool IsReturned { get; set; }

    public bool IsResellable { get; set; }

}
