namespace TataGamedomWebAPI.Models.DTOs.Post
{
	public class PostCreateDto
	{
        public string MemberAccount { get; set; }
		public int BoardId { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
    }
}
