namespace TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Response.Payment;

public class ResponseInfoDto
{
    public ResponsePaymentUrlDto PaymentUrl { get; set; }
    public long TransactionId { get; set; }
    public string PaymentAccessToken { get; set; }
}
