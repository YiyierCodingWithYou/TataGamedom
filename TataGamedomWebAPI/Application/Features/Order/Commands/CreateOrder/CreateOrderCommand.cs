using MediatR;

namespace TataGamedomWebAPI.Application.Features.Order.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<int>
{
    public int MyProperty { get; set; }
    public int MemberId { get; set; }
    public string? RecipientName { get; set; }
    public string? ToAddress { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int OrderStatusId { get; set; } = 1;
    public int ShipmentStatusId { get; set; } = 1;
    public int PaymentStatusId { get; set; } = 1;
    public int ShipmemtMethodId { get; set; } = 1;
}
