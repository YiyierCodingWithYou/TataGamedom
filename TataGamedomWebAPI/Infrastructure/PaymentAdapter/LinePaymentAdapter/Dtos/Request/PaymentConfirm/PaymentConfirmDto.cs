namespace TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.PaymentConfirm;

public class PaymentConfirmDto
{
    public int Amount { get; set; }
    public string Currency { get; set; } = "TWD";
}