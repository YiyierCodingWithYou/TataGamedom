using TataGamedomWebAPI.Models.DTOs.Shop;

namespace TataGamedomWebAPI.Models.DTOs.Cart
{
	public class CartItemDTO
	{

		public ProductsDTO? Product { get; set; }

		public int Qty { get; set; }
		public int SubTotal => Product.SpecialPrice * Qty;
	}
}
