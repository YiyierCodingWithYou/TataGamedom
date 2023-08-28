using MediatR;

namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.UpdateOrderItemReturn.UpdateAfterLinePayRefund;

public class UpdateAfterLinePayRefund : IRequest<Unit>
{
    public int Id { get; set; }

    public bool IsRefunded { get; set; }

    public DateTime? CompletedAt { get; set; }

    public string? LinePayRefundTransactionId { get; set; }
}
