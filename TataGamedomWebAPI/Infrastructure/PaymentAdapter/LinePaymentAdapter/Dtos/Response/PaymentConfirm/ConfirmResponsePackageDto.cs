namespace TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Response.PaymentConfirm;

public class ConfirmResponsePackageDto
{
    public string Id { get; set; }
    public int Amount { get; set; }
    public int UserFeeAmount { get; set; }
}
