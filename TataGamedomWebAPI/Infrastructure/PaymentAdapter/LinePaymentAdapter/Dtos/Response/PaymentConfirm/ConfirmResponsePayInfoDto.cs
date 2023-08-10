namespace TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Response.PaymentConfirm;

public class ConfirmResponsePayInfoDto
{
    public string Method { get; set; }
    public int Amount { get; set; }
    public string CreditCardNickname { get; set; }
    public string CreditCardBrand { get; set; }
    public string MaskedCreditCardNumber { get; set; }
    public ConfirmResponsePackageDto[] Packages { get; set; }
    public ConfirmResponseShippingOptionsDto Shipping { get; set; }
}
