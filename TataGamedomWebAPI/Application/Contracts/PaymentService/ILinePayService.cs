using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.PaymentRefund;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Response.PaymentRefund;

namespace TataGamedomWebAPI.Application.Contracts.PaymentService;

public interface ILinePayService
{
    Task<PaymentRefundResponseDto> RefundPayment(string transactionId, PaymentRefundRequestDto dto);
}
