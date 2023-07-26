namespace TataGamedomWebAPI.Models.Dtos.OrderDto;

public record OrderUpdateDto(
    int Id,
    int OrderStatusId,
    int ShipmentStatusId,
    int PaymentStatusId,
    int ShipmemtMethodId,
    string? TrackingNum);
