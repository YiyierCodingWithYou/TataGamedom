namespace TataGamedomWebAPI.Models.DTOs.News
{
    public class NewsCommentsDTO
	{
		public int Id { get; set; }

		public int NewsId { get; set; }

		public int MemberId { get; set; }

		public string Content { get; set; } = null!;

		public bool ActiveFlag { get; set; }

		public DateTime Time { get; set; }
	}
}
