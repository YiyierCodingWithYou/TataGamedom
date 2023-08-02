using MediatR;

namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.CreateOrderItemReturn;

public class CreateOrderItemReturnCommand : IRequest<int>
{
    public string Index { get; set; } = string.Empty;

    public int OrderItemId { get; set; }

    public string? Reason { get; set; } = string.Empty;

    public DateTime IssuedAt { get; set; } = DateTime.Now;

    public bool IsRefunded { get; set; } = false;

    public bool IsReturned { get; set; } = false;

    public bool IsResellable { get; set; } = false;

}
