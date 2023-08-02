namespace TataGamedomWebAPI.Models.DTOs.News
{
    public class NewsDto
	{
		public int Id { get; set; }

		public string Title { get; set; } = null!;

		public string Content { get; set; } = null!;

		//public int BackendMemberId { get; set; }
		public string BackendMemberName { get; set; } = null!;

		public int NewsCategoryId { get; set; }

		public int? GamesId { get; set; }

		public string? CoverImg { get; set; }

		public DateTime ScheduleDate { get; set; }

		public bool ActiveFlag { get; set; }

		//public DateTime? EditDatetime { get; set; }

		//public DateTime? DeleteDatetime { get; set; }

		//public int? DeleteBackendMemberId { get; set; }
	}
}
