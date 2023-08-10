namespace TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.Payment;

public class PaymentRequestDto
{
    public int Amount { get; set; }
    public string Currency { get; set; }
    public string OrderId { get; set; }
    public List<PackageDto> Packages { get; set; }
    public RedirectUrlsDto RedirectUrls { get; set; }
    public RequestOptionDto? Options { get; set; }
}
