using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels;

public partial class Product
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public int? GameId { get; set; }

    public bool IsVirtual { get; set; }

    public int Price { get; set; }

    public int GamePlatformId { get; set; }

    public string SystemRequire { get; set; } = null!;

    public int ProductStatusId { get; set; }

    public DateTime SaleDate { get; set; }

    public int CreatedBackendMemberId { get; set; }

    public DateTime CreatedTime { get; set; }

    public int? ModifiedBackendMemberId { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<CouponsProduct> CouponsProducts { get; set; } = new List<CouponsProduct>();

    public virtual BackendMember CreatedBackendMember { get; set; } = null!;

    public virtual Game? Game { get; set; }

    public virtual GamePlatformsCode GamePlatform { get; set; } = null!;

    public virtual ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();

    public virtual ICollection<MemberProductView> MemberProductViews { get; set; } = new List<MemberProductView>();

    public virtual BackendMember? ModifiedBackendMember { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ProductStatusCode ProductStatus { get; set; } = null!;

    public virtual ICollection<StandardProduct> StandardProducts { get; set; } = new List<StandardProduct>();
}
