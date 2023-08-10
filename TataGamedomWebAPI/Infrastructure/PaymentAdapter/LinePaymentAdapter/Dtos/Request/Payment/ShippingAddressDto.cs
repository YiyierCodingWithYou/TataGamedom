namespace TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.Payment;

public class ShippingAddressDto
{
    public string? Country { get; set; }
    public string? PostalCode { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string? Detail { get; set; }
    public string? Optional { get; set; }
    public ShippingAddressRecipientDto Recipient { get; set; }
}
