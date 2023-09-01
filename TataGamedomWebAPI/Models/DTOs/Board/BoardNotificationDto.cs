namespace TataGamedomWebAPI.Models.DTOs.Board
{
	public class BoardNotificationDto
	{
		public int Id { get; set; }
		public int RecipientMemberId { get; set; }
		public int? RelationMemberId { get; set; }
		public int? RelationPostId { get; set; }
		public string Content { get; set; } = null!;
		public string? Link { get; set; }
		public bool IsReaded { get; set; }
		public DateTime CreateTime { get; set; }
		public DateTime? ReadTime { get; set; }
	}
}
