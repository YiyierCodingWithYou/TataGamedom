namespace TataGamedomWebAPI.Infrastructure.ShipmentAdapter.Dtos.Request;

public class RqHeader
{
    public string Timestamp { get; set; }

    /// <summary>
    /// 當前時間轉換為時間戳(GMT+8)
    /// </summary>
    public RqHeader()
    {
        DateTimeOffset taipeiTime = DateTimeOffset.UtcNow.AddHours(8);

        long unixTimestamp = taipeiTime.ToUnixTimeSeconds();

        Timestamp = unixTimestamp.ToString();
    }
}