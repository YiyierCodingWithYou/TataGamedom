using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels
{
    public partial class BackendMember
    {
        public BackendMember()
        {
            Boards = new HashSet<Board>();
            BoardsModeratorsApplications = new HashSet<BoardsModeratorsApplication>();
            BucketLogs = new HashSet<BucketLog>();
            CouponCreatedBackendMembers = new HashSet<Coupon>();
            CouponModifiedBackendMembers = new HashSet<Coupon>();
            GameComments = new HashSet<GameComment>();
            GameCreatedBackendMembers = new HashSet<Game>();
            GameModifiedBackendMembers = new HashSet<Game>();
            NewsBackendMembers = new HashSet<News>();
            NewsComments = new HashSet<NewsComment>();
            NewsDeleteBackendMembers = new HashSet<News>();
            Newsletters = new HashSet<Newsletter>();
            PostCommentReports = new HashSet<PostCommentReport>();
            PostComments = new HashSet<PostComment>();
            PostReports = new HashSet<PostReport>();
            Posts = new HashSet<Post>();
            ProductCreatedBackendMembers = new HashSet<Product>();
            ProductModifiedBackendMembers = new HashSet<Product>();
            Replies = new HashSet<Reply>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Account { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int BackendMembersRoleId { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public bool ActiveFlag { get; set; }

        public virtual BackendMembersRolesCode BackendMembersRole { get; set; } = null!;
        public virtual ICollection<Board> Boards { get; set; }
        public virtual ICollection<BoardsModeratorsApplication> BoardsModeratorsApplications { get; set; }
        public virtual ICollection<BucketLog> BucketLogs { get; set; }
        public virtual ICollection<Coupon> CouponCreatedBackendMembers { get; set; }
        public virtual ICollection<Coupon> CouponModifiedBackendMembers { get; set; }
        public virtual ICollection<GameComment> GameComments { get; set; }
        public virtual ICollection<Game> GameCreatedBackendMembers { get; set; }
        public virtual ICollection<Game> GameModifiedBackendMembers { get; set; }
        public virtual ICollection<News> NewsBackendMembers { get; set; }
        public virtual ICollection<NewsComment> NewsComments { get; set; }
        public virtual ICollection<News> NewsDeleteBackendMembers { get; set; }
        public virtual ICollection<Newsletter> Newsletters { get; set; }
        public virtual ICollection<PostCommentReport> PostCommentReports { get; set; }
        public virtual ICollection<PostComment> PostComments { get; set; }
        public virtual ICollection<PostReport> PostReports { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Product> ProductCreatedBackendMembers { get; set; }
        public virtual ICollection<Product> ProductModifiedBackendMembers { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
