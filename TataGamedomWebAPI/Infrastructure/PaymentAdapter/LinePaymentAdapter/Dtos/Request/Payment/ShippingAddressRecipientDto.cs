namespace TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.Payment;

public class ShippingAddressRecipientDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FirstNameOptional { get; set; }
    public string? LastNameOptional { get; set; }
    public string? Email { get; set; }
    public string? PhoneNo { get; set; }
    public string? Type { get; set; }
}
