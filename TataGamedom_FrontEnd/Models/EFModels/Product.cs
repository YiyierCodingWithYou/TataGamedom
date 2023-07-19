using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            CouponsProducts = new HashSet<CouponsProduct>();
            InventoryItems = new HashSet<InventoryItem>();
            MemberProductViews = new HashSet<MemberProductView>();
            OrderItems = new HashSet<OrderItem>();
            ProductImages = new HashSet<ProductImage>();
            StandardProducts = new HashSet<StandardProduct>();
        }

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

        public virtual BackendMember CreatedBackendMember { get; set; } = null!;
        public virtual Game? Game { get; set; }
        public virtual GamePlatformsCode GamePlatform { get; set; } = null!;
        public virtual BackendMember? ModifiedBackendMember { get; set; }
        public virtual ProductStatusCode ProductStatus { get; set; } = null!;
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<CouponsProduct> CouponsProducts { get; set; }
        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
        public virtual ICollection<MemberProductView> MemberProductViews { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<StandardProduct> StandardProducts { get; set; }
    }
}
