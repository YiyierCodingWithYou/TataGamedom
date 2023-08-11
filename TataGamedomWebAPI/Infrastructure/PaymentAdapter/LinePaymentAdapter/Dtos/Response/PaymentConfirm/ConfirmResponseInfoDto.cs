namespace TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Response.PaymentConfirm;

public class ConfirmResponseInfoDto
{
    public string OrderId { get; set; }
    public long TransactionId { get; set; }
    public string AuthorizationExpireDate { get; set; }
    public string RegKey { get; set; }
    public ConfirmResponsePayInfoDto[] PayInfo { get; set; }
}
