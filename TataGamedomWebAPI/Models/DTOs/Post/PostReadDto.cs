using TataGamedomWebAPI.Models.Dtos;

namespace TataGamedomWebAPI.Models.DTOs.Post
{
    public class PostReadDto
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string PostContent { get; set; }
        public DateTime DateTime { get; set; }
        public int BoardId { get; set; }
        public string? BoardName { get; set; }
        public int MemberId { get; set; }
        public string MemberAccount { get; set; }
        public string MemberName { get; set; }
        public int VoteUp { get; set; }
        public int VoteDown { get; set; }
        public int CommentCount { get; set; }
        public bool IsEdited { get; set; }
        public bool IsAuthor { get; set; }
        public bool IsMod { get; set; }
        public string? Voted { get; set; }
        public DateTime LastEditDatetime { get; set; }
        public IEnumerable<CommentReadDto> Comments { get; set; }
    }
}

