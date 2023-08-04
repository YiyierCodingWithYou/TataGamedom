namespace TataGamedomWebAPI.Models.DTOs.PostComment
{
	public class CommentCreateDto
	{
		public int PostId { get; set; }
		public string Content { get; set; }
    }
}