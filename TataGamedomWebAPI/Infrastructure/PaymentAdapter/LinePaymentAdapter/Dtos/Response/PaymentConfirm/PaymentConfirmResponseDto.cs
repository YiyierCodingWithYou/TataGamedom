namespace TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Response.PaymentConfirm;

public class PaymentConfirmResponseDto
{
    public string ReturnCode { get; set; }
    public string ReturnMessage { get; set; }
    public ConfirmResponseInfoDto Info { get; set; }
}
