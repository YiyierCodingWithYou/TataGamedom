using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Models.DTOs
{
	public class ProductsIndexDTO
	{
		public List<Product>? Products { get; set; }
		public int TotalPages { get; set; }
	}
}
