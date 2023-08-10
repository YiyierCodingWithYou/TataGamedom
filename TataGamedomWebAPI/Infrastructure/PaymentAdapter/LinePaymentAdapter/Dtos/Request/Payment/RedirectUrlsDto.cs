namespace TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.Payment;

public class RedirectUrlsDto
{
    public string ConfirmUrl { get; set; }
    public string CancelUrl { get; set; }
    public string? AppPackageName { get; set; }
    public string? ConfirmUrlType { get; set; }
}
