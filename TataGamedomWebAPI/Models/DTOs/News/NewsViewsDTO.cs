namespace TataGamedomWebAPI.Models.DTOs.News
{
    public class NewsViewsDTO
	{
		public int Id { get; set; }

		public int NewsId { get; set; }

		public int MemberId { get; set; }

		public DateTime ViewTime { get; set; }
	}
}
