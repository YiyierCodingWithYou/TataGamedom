using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.Payment;

namespace TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Response.PaymentConfirm;

public class ConfirmResponseShippingOptionsDto
{
    public string MethodId { get; set; }
    public int FeeAmount { get; set; }
    public ShippingAddressDto Address { get; set; }
}
