using TataGamedomWebAPI.Models.DTOs.Cart;

namespace TataGamedomWebAPI.Models.DTOs.Shop
{
	public class TrackProductDTO
	{
		public IEnumerable<SingleProductDTO>? TrackItems { get; set; }

	}
}
