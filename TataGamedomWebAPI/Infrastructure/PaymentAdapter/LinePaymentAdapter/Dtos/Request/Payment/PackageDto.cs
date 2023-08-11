namespace TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.Payment;

public class PackageDto
{
    public string Id { get; set; }
    public int Amount { get; set; }
    public string Name { get; set; }
    public List<LinePayProductDto> Products { get; set; }
    public int? UserFee { get; set; }

}
