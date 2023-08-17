namespace TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.Payment;

public class PackageDto
{

    public string Id { get; set; }

    /// <summary>
    /// 小計
    /// </summary>
    public int Amount { get; set; }

    /// <summary>
    /// GameName
    /// </summary>
    public string? Name { get; set; }
    public List<LinePayProductDto> Products { get; set; }
    public int? UserFee { get; set; }

}
