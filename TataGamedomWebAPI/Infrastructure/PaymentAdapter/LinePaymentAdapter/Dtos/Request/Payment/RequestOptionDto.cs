namespace TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.Payment;

public class RequestOptionDto
{
    public PaymentOptionDto? Payment { get; set; }
    public DisplpyOptionDto? Display { get; set; }
    public ShippingOptionDto? Shipping { get; set; }
    public ExtraOptionsDto? Extra { get; set; }
}
