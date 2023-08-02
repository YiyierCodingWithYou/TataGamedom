using MediatR;
using TataGamedomWebAPI.Application.Features.Order.Shared;

namespace TataGamedomWebAPI.Application.Features.Order.Commands.CreateOrder;

public class CreateOrderCommand :BaseOrder, IRequest<int>
{
    public int MemberId { get; set; }
    public string? ToAddress { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

}
