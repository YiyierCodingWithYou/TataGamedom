using MediatR;
using System.ComponentModel.DataAnnotations;
using TataGamedomWebAPI.Application.Features.Order.Shared;

namespace TataGamedomWebAPI.Application.Features.Order.Commands.UpdateOrder;

public class UpdateOrderCommand: IRequest<Unit>    //BaseOrder
{
    public string Index { get; set; } = string.Empty;
    public DateTime? SentAt { get; set; }      //出貨
    public DateTime? DeliveredAt { get; set; } //送達超商門市
    public DateTime? CompletedAt { get; set; } //完成時間(取貨時間)
    public string? TrackingNum { get; set; }

    public int OrderStatusId { get; set; }

    public int? ShipmentStatusId { get; set; }

    public int PaymentStatusId { get; set; }
}

