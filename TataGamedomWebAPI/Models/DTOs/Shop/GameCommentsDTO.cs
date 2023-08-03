namespace TataGamedomWebAPI.Models.DTOs.Shop
{
	public class GameCommentsDTO
	{
		public int Id { get; set; }

		public string MemberName { get; set; }

		public string Content { get; set; } = null!;

		public byte Score { get; set; }

		public DateTime CreatedTime { get; set; }
	}
}
