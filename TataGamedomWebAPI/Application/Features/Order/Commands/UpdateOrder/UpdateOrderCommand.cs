using MediatR;
using TataGamedomWebAPI.Application.Features.Order.Shared;

namespace TataGamedomWebAPI.Application.Features.Order.Commands.UpdateOrder;

public class UpdateOrderCommand : BaseOrder, IRequest<Unit> 
{
    public int Id { get; set; }
    public DateTime? CompletedAt { get; set; } 
    public DateTime? DeliveredAt { get; set; } 
    public string? TrackingNum { get; set; }

}

