using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class ShipmentMethod
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Cost { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
