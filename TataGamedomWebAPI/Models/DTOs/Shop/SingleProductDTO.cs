using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Models.DTOs.Shop
{
	public class SingleProductDTO
	{
		public int Id { get; set; }

		public string Index { get; set; } = null!;

		public bool IsVirtual { get; set; }
        public int? GameId { get; set; }

        public int Price { get; set; }
		public int SpecialPrice { get; set; }
		public string GamePlatformName { get; set; }
		public double Score { get; set; }

		public DateTime SaleDate { get; set; }

		public string ChiName { get; set; } = null!;

		public string EngName { get; set; } = null!;
        public string Description { get; set; }

        public string SystemRequire { get; set; }
        public bool IsRestrict { get; set; }

		public string GameCoverImg { get; set; } = null!;
        public IEnumerable<string>? Coupons { get; set; }
        public IEnumerable<string>? CouponDescription { get; set; }
        public IEnumerable<string>? ProductImg { get; set; }

        public IEnumerable<string>? Classification { get; set; }

		public int CommentCount { get; set; }
        public IEnumerable<GameCommentsDTO> GameComments { get; set; }

        public int TotalPages { get; set; }
    }
}
