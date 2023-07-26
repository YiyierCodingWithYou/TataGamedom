using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Models.Dtos;

public class OrderCreateDto
{
    public int MemberId { get; set; }

    public int OrderStatusId { get; set; }

    public int ShipmentStatusId { get; set; }

    public int PaymentStatusId { get; set; }

    public int ShipmemtMethodId { get; set; }

    public string? RecipientName { get; set; }

    public string? ToAddress { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

}
