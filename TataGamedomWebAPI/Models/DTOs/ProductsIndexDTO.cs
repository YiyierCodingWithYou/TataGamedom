using TataGamedomWebAPI.Models.Dtos;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Models.DTOs
{
	public class ProductsIndexDTO
	{
		public List<ProductsDTO>? Products { get; set; }
		public int TotalPages { get; set; }
	}
}
