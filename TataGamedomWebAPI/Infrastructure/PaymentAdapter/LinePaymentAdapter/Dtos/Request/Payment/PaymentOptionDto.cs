namespace TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.Payment;

public class PaymentOptionDto
{
    public bool? Capture { get; set; }
    public string? PayType { get; set; }
}
