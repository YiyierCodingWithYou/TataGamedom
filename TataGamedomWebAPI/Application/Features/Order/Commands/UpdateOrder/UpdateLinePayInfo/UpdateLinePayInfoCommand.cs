using MediatR;

namespace TataGamedomWebAPI.Application.Features.Order.Commands.UpdateOrder.UpdateLinePayInfo;

public class UpdateLinePayInfoCommand : IRequest<Unit>
{
    public string Index { get; set; } = string.Empty;

    public int? PaymentStatusId { get; set; }

    public string? LinePayTransactionId { get; set; } = string.Empty;

    public DateTime PaidAt { get; set; }

    public string? MaskedCreditCardNumber { get; set; } = string.Empty;

}
