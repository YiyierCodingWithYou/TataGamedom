using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class Order
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public int MemberId { get; set; }

    public int OrderStatusId { get; set; }

    public int? ShipmentStatusId { get; set; }

    public int PaymentStatusId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public int? ShipmentMethodId { get; set; }

    public string? RecipientName { get; set; }

    public string? ToAddress { get; set; }

    public DateTime? SentAt { get; set; }

    public DateTime? DeliveredAt { get; set; }

    public string? TrackingNum { get; set; }

    public string? ContactEmails { get; set; }

    public int? ShippingFee { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual OrderStatusCode OrderStatus { get; set; } = null!;

    public virtual PaymentStatusCode PaymentStatus { get; set; } = null!;

    public virtual ShipmemtMethod? ShipmentMethod { get; set; }

    public virtual ShipmentStatusesCode? ShipmentStatus { get; set; }
}
