namespace TataGamedomWebAPI.Infrastructure.ShipmentAdapter.Dtos.Request.QueryLogisticsTradeInfo;

public class QueryLogisticsTradeInfoDto
{
    public string MerchantID { get; set; } = "2000132";
    public string? LogisticsID { get; set; }
    public string? MerchantTradeNo { get; set; } = "TataGamedomWeb";  //todo OrderId
}
