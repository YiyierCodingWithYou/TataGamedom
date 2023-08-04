using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Models.DTOs.Shop
{
    public class ProductsIndexDTO
    {
        public List<ProductsDTO>? Products { get; set; }
        public int TotalPages { get; set; }
    }
}
