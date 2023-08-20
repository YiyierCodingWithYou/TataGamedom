namespace TataGamedomWebAPI.Infrastructure.ShipmentAdapter.Dtos.Response;

public class QueryLogisticsTradeInfoResponseDto
{
    public string PlatformID { get; set; }
    public string MerchantID { get; set; }
    public RpHeader RpHeader { get; set; }
    public int TransCode { get; set; }
    public string TransMsg { get; set; }

    public string Data { get; set; }


}

public class TradeInfoResponseData
{
    public int RtnCode { get; set; }
    public string RtnMsg { get; set; }
    public string MerchantID { get; set; }
    public string MerchantTradeNo { get; set; }
    public string LogisticsID { get; set; }
    public int GoodsAmount { get; set; }
    public string LogisticsType { get; set; }
    public int HandlingCharge { get; set; }
    public int CollectionAmount { get; set; }
    public int CollectionChargeFee { get; set; }
    public string TradeDate { get; set; }
    public string LogisticsStatus { get; set; }   //todo 根據編號看能不能demo，測試環境不會改變狀態
    public string GoodsName { get; set; }
    public string ShipmentNo { get; set; }
    public string BookingNote { get; set; }
    public string CVSPaymentNo { get; set; }
    public string CVSValidationNo { get; set; }
    public double GoodsWeight { get; set; }
    public double ActualWeight { get; set; }
    public string ShipChargeDate { get; set; }
    public string CollectionAllocateDate { get; set; }
    public int CollectionAllocateAmount { get; set; }
}