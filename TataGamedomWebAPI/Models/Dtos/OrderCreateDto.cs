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
}

public static class OrderDtoExts
{
    public static OrderCreateDto ToDto(this Order entity)
    {
        return new OrderCreateDto
        {
            MemberId = entity.MemberId,
            OrderStatusId = entity.OrderStatusId,
            ShipmentStatusId = entity.ShipmentStatusId,
            PaymentStatusId = entity.PaymentStatusId,
            ShipmemtMethodId = entity.ShipmemtMethodId,
            RecipientName = entity.RecipientName,
            ToAddress = entity.ToAddress,
        };
    }
}
