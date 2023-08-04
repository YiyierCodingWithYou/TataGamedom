using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Models.DTOs.Cart
{
	public class CartItemCreateDTO
	{
		public int MemberId { get; set; }

		public int ProductId { get; set; }

		public int Qty { get; set; }

	}
}
