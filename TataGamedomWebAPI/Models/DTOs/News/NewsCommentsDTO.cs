namespace TataGamedomWebAPI.Models.DTOs.News
{
    public class NewslikesDTO
	{
		public int Id { get; set; }

		public int NewsId { get; set; }

		public int MemberId { get; set; }

		public DateTime Time { get; set; }
	}
}
