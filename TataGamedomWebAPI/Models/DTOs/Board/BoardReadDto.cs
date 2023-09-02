namespace TataGamedomWebAPI.Models.DTOs.Board
{
	public class BoardReadDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string BoardAbout { get; set; }
		public string BoardHeaderCoverImgUrl { get; set; }
		public string BoardUrl { get; set; }
		public int? GameId { get; set; }
		public string? GameName { get; set; }
		public int PostCurrentCount { get; set; }
		public int PostTotalCount { get; set; }
		public int MemberFollowCount { get; set; }
		public bool? IsFollowed { get; set; }
		public bool? IsFavorite { get; set; }
		public bool? IsMod { get; set; }
		public bool? IsBucket { get; set; }
		public DateTime? BucketEndTime { get; set; }
		public IEnumerable<ModReadDto> Mods { get; set; }
		public IEnumerable<ProducLinkDto> ProductLinks { get; set; }
	}

	public class ModReadDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Account { get; set; }
		public string IconUrl { get; set; }
	}

	public class ProducLinkDto
	{
		public int Id { get; set; }
		public string PlatformName { get; set; }
		public string Url { get; set; }
	}
}
