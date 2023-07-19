using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels
{
    public partial class Board
    {
        public Board()
        {
            BoardsModerators = new HashSet<BoardsModerator>();
            BoardsModeratorsApplications = new HashSet<BoardsModeratorsApplication>();
            BucketLogs = new HashSet<BucketLog>();
            MembersBoards = new HashSet<MembersBoard>();
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? GameId { get; set; }
        public string? BoardAbout { get; set; }
        public string? BoardHeaderCoverImg { get; set; }
        public DateTime CreatedTime { get; set; }
        public int CreatedBackendMemberId { get; set; }

        public virtual BackendMember CreatedBackendMember { get; set; } = null!;
        public virtual Game? Game { get; set; }
        public virtual ICollection<BoardsModerator> BoardsModerators { get; set; }
        public virtual ICollection<BoardsModeratorsApplication> BoardsModeratorsApplications { get; set; }
        public virtual ICollection<BucketLog> BucketLogs { get; set; }
        public virtual ICollection<MembersBoard> MembersBoards { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
