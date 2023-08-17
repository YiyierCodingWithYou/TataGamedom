namespace TataGamedomWebAPI.Models.Dtos
{
	public class CommentReadDto
	{
        public int CommentId { get; set; }
		public string CommentContent { get; set; }
		public DateTime DateTime { get; set; }
		public string MemberAccount { get; set; }
		public string MemberName { get; set; }
        public int VoteUp { get; set; }
		public int VoteDown { get; set; }
		public bool IsAuthor { get; set; }
		public bool IsMod { get; set; }
		public string? Voted { get; set; }
		public int PostId { get; set; }
		public bool ActiveFlag { get; set; }
		public IEnumerable<CommentReadDto> Comments { get; set; }
	}
}
