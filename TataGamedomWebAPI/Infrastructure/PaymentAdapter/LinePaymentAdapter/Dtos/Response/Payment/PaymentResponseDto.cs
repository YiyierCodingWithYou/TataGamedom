namespace TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Response.Payment;

public class PaymentResponseDto
{
    public string ReturnCode { get; set; }
    public string ReturnMessage { get; set; }
    public ResponseInfoDto Info { get; set; }
}
