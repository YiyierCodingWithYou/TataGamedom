namespace TataGamedomWebAPI.Models.DTOs.News
{
	public class NewsListDto
	{
		public int TotalPage { get; set; }
		public IEnumerable<NewsDto> News { get; set; }
	}
}
