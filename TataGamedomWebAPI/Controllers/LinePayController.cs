using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.Payment;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.PaymentConfirm;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Response.Payment;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Response.PaymentConfirm;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter;
using Microsoft.AspNetCore.Cors;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.PaymentRefund;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Response.PaymentRefund;

namespace TataGamedomWebAPI.Controllers;


[ApiController]
[Route("api/[Controller]")]
[EnableCors("AllowAny")]
public class LinePayController : ControllerBase
{
    private readonly LinePayService _linePayService;
    public LinePayController()
    {
        _linePayService = new LinePayService();
    }

    [HttpPost("Create")]
    public async Task<PaymentResponseDto> CreatePayment(PaymentRequestDto dto)
    {

        return await _linePayService.SendPaymentRequest(dto);
    }

    [HttpPost("Confirm")]
    public async Task<PaymentConfirmResponseDto> ConfirmPayment([FromQuery] string transactionId, [FromQuery] string orderId, PaymentConfirmDto dto)
    {
        return await _linePayService.ConfirmPayment(transactionId, orderId, dto);
    }


    [HttpPost("Refund")]
    public async Task<PaymentRefundResponseDto> RefundPayment([FromQuery] string transactionId, PaymentRefundRequestDto dto)
    {
        return await _linePayService.RefundPayment(transactionId,dto);
    }

    [HttpGet("Cancel")]
    public async void CancelTransaction([FromQuery] string transactionId)
    {
        _linePayService.TransactionCancel(transactionId);
    }
}
