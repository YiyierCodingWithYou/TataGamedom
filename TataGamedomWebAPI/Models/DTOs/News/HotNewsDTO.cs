namespace TataGamedomWebAPI.Models.DTOs.News
{
	public class HotNewsDTO
	{
		public int Id { get; set; }

		public string Title { get; set; } = null!;

		public string? CoverImg { get; set; }

		public DateTime ScheduleDate { get; set; }
	}
}
