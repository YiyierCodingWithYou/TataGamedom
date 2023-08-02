namespace TataGamedomWebAPI.Models.DTOs.Shop
{
    public class ProductsDTO
    {
        public int Id { get; set; }

        public string Index { get; set; } = null!;

        public bool IsVirtual { get; set; }

        public int Price { get; set; }
        public int SpecialPrice { get; set; }
        public string GamePlatformName { get; set; }
        public double Score { get; set; }

        public DateTime SaleDate { get; set; }

        public string ChiName { get; set; } = null!;

        public string EngName { get; set; } = null!;
        public bool IsRestrict { get; set; }

        public string GameCoverImg { get; set; } = null!;

        public IEnumerable<string> Classification { get; set; }
    }
}
