namespace TataGamedomWebAPI.Models.DTOs.Cart
{
	public class CartDTO
	{
		public int Id { get; set; }

		public int MemberId { get; set; }
		public IEnumerable<CartItemDTO> CartItems { get; set; }
		public int Total
		{
			get
			{
				return CartItems.Sum(item => item.SubTotal);
			}
		}
		public IEnumerable<string> distinctCoupons { get; set; }
		public IEnumerable<string> distinctCouponsDescription { get; set; }
		public bool AllowCheckout => CartItems.Any();



	}
}
