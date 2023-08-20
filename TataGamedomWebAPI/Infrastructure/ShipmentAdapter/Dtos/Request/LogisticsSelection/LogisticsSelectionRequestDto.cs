using System.Reflection.PortableExecutable;

namespace TataGamedomWebAPI.Infrastructure.ShipmentAdapter.Dtos.Request.LogisticsSelection;

public class LogisticsSelectionRequestDto
{
    public string MerchantID { get; set; } = "2000132";

    public required RqHeader RqHeader { get; set; }

    public string Data { get; set; } = string.Empty;

}
