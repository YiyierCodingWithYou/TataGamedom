namespace TataGamedomWebAPI.Models.DTOs.Shop
{
	public class TrackProducDTO
	{
        public int ProductId { get; set; }
        public string ProductChiName { get; set; }
        public string ProductPlatform { get; set; }
		public int Price { get; set; }
		public int SpecialPrice { get; set; }
	}
}
