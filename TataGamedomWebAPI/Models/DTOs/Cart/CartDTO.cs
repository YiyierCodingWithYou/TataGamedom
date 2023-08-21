namespace TataGamedomWebAPI.Models.DTOs.Cart
{
	public class CartDTO
	{
		public int Id { get; set; }

		public int MemberId { get; set; }
		public IEnumerable<CartItemDTO> CartItems { get; set; }
        public int SubTotal
		{
			get
			{
				return CartItems.Sum(item => item.SubTotal);
			}
		}
		public int Total
		{
			get
			{
				int total = CartItems.Sum(item => item.SubTotal);

				if (total > 3000)
				{
					total -= 300;
				}

				return total;
			}
		}
		public IEnumerable<string> distinctCoupons { get; set; }
		public IEnumerable<string> distinctCouponsDescription { get; set; }
		public bool AllowCheckout => CartItems.Any();



	}
}
