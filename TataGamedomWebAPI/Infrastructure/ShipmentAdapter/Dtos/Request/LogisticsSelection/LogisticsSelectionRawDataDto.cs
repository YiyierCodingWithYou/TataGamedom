namespace TataGamedomWebAPI.Infrastructure.ShipmentAdapter.Dtos.Request.LogisticsSelection;

public class LogisticsSelectionRawDataDto
{
    public string TempLogisticsID { get; set; } = "0";
    public decimal GoodsAmount { get; set; } = 100;
    public string IsCollection { get; set; } = "N";
    public string GoodsName { get; set; } = "TataProduct";
    public string SenderName { get; set; } = "Tata";
    public string SenderZipCode { get; set; } = "320";
    public string SenderAddress { get; set; } = "桃園市中壢區新生路二段421號";
    public string Remark { get; set; } = "xxx";
    public string ServerReplyURL { get; set; } = "https://localhost:3000/Orders";  //todo ngrok
    public string ClientReplyURL { get; set; } = "https://localhost:3000/Carts";   //todo ngrok
    public string Temperature { get; set; } = "0001";
    public string Specification { get; set; } = "0001";
    public string ScheduledPickupTime { get; set; } = "4";  //宅配物流商預定取貨的時段
    public string ReceiverAddress { get; set; } = "桃園市中壢區新生路二段421號";
    public string ReceiverCellPhone { get; set; } = "0916224867";
    public string ReceiverPhone { get; set; } = "xxxxxxxx";
    public string ReceiverName { get; set; } = "lisi"; //todo
    public string EnableSelectDeliveryTime { get; set; } = "Y";  //是否允許選擇送達時間
    public string EshopMemberID { get; set; } = "xxxxyyyy123";
}
