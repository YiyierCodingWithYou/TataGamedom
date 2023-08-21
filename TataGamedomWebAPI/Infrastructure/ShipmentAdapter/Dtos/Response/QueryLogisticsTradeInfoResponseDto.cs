namespace TataGamedomWebAPI.Infrastructure.ShipmentAdapter.Dtos.Response;

public class QueryLogisticsTradeInfoResponseDto
{
    public string PlatformID { get; set; }
    public string MerchantID { get; set; }
    public RpHeader RpHeader { get; set; }
    public int TransCode { get; set; }
    public string TransMsg { get; set; }
    public string Data { get; set; }
    public TradeInfoResponseData DecodedData { get; set; }

}

public class TradeInfoResponseData
{
    public int? RtnCode { get; set; }
    public string RtnMsg { get; set; } = string.Empty;
    public string MerchantID { get; set; } = string.Empty;
    public string MerchantTradeNo { get; set; } = string.Empty;
    public string LogisticsID { get; set; } = string.Empty;
    public int? GoodsAmount { get; set; }
    public string LogisticsType { get; set; } = string.Empty;
    public int? HandlingCharge { get; set; }
    public int? CollectionAmount { get; set; }
    public int? CollectionChargeFee { get; set; }
    public string TradeDate { get; set; } = string.Empty;
    public string LogisticsStatus { get; set; } = string.Empty;  //todo 根據編號看能不能demo，測試環境不會改變狀態
    public string GoodsName { get; set; } = string.Empty;
    public string ShipmentNo { get; set; } = string.Empty;
    public string BookingNote { get; set; } = string.Empty;
    public string CVSPaymentNo { get; set; } = string.Empty;
    public string CVSValidationNo { get; set; } = string.Empty;
    public double? GoodsWeight { get; set; }
    public double? ActualWeight { get; set; }
    public string ShipChargeDate { get; set; } = string.Empty;
    public string CollectionAllocateDate { get; set; } = string.Empty;
    public int? CollectionAllocateAmount { get; set; }
}