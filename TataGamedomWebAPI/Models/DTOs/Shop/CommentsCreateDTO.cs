namespace TataGamedomWebAPI.Models.DTOs.Shop
{
	public class CommentsCreateDTO
	{
        //public int productId { get; set; }
        public int GameId { get; set; }

		public int MemberId { get; set; }

		public string Content { get; set; } = null!;

		public byte Score { get; set; }

        public bool ActiveFlag { get; set; }

        public DateTime CreatedTime { get; set; }
	}
}
