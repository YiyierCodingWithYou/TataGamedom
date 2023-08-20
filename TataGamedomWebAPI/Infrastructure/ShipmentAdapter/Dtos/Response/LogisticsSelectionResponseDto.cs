namespace TataGamedomWebAPI.Infrastructure.ShipmentAdapter.Dtos.Response;

public class LogisticsSelectionResponseDto
{
    public required string ResultData { get; set; }

}

public class ResultData 
{
    //todo
}

public class Data 
{
    public int RtnCode { get; set; }
    public string RtnMsg { get; set; } = string.Empty;
    public string TempLogisticsID { get; set; } = string.Empty;
    public string LogisticsType { get; set; } = string.Empty;
    public string LogisticsSubType { get; set; } = string.Empty;
    public string ReceiverName { get; set; } = string.Empty;
    public string ReceiverPhone { get; set; } = string.Empty;
    public string ReceiverCellphone { get; set; } = string.Empty;
    public string ReceiverAddress { get; set; } = string.Empty;
    public string ReceiverZipCode { get; set; } = string.Empty;
    public string ScheduledDeliveryDate { get; set; } = string.Empty;
    public string ScheduledDeliveryTime { get; set; } = string.Empty;
    public string ReceiverStoreID { get; set; } = string.Empty;
    public string ReceiverStoreName { get; set; } = string.Empty;
}


