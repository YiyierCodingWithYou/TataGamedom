namespace TataGamedomWebAPI.Models.DTOs.News
{
	public class SingleNewsDTO
	{
		public int Id { get; set; }

		public string Title { get; set; } = null!;

		public string Content { get; set; } = null!;

		public string BackendMemberName { get; set; } = null!;

		public string NewsCategoryName { get; set; }

		//遊戲類別名稱
		public string Name { get; set; }

		public int ViewCount { get; set; }

		public int LikeCount { get; set; }

		public string? CoverImg { get; set; }

		public DateTime ScheduleDate { get; set; }

		public bool ActiveFlag { get; set; }
	}
}
