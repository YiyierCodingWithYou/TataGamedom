namespace TataGamedomWebAPI.Models.DTOs.Post
{
	public class PostCreateDto
	{
		public int BoardId { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
    }
}
