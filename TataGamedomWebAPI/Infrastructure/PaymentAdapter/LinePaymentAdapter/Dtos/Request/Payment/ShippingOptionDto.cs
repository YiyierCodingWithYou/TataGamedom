namespace TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.Payment;

public class ShippingOptionDto
{
    public string? Type { get; set; }
    public int FeeAmount { get; set; }
    public string? FeeInquiryUrl { get; set; }
    public string? FeeInquiryType { get; set; }
    public ShippingAddressDto? Address { get; set; }
}
