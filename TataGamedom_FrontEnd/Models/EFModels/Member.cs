using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels
{
    public partial class Member
    {
        public Member()
        {
            BoardsModerators = new HashSet<BoardsModerator>();
            BoardsModeratorsApplications = new HashSet<BoardsModeratorsApplication>();
            BucketLogBucketMembers = new HashSet<BucketLog>();
            BucketLogModeratorMembers = new HashSet<BucketLog>();
            Carts = new HashSet<Cart>();
            GameComments = new HashSet<GameComment>();
            Issues = new HashSet<Issue>();
            MemberProductViews = new HashSet<MemberProductView>();
            MembersBoards = new HashSet<MembersBoard>();
            NewsCommentDeleteMembers = new HashSet<NewsComment>();
            NewsCommentMembers = new HashSet<NewsComment>();
            NewsLikes = new HashSet<NewsLike>();
            NewsViews = new HashSet<NewsView>();
            NewsletterLogs = new HashSet<NewsletterLog>();
            Orders = new HashSet<Order>();
            PostCommentDeleteMembers = new HashSet<PostComment>();
            PostCommentMembers = new HashSet<PostComment>();
            PostCommentReports = new HashSet<PostCommentReport>();
            PostCommentUpDownVotes = new HashSet<PostCommentUpDownVote>();
            PostDeleteMembers = new HashSet<Post>();
            PostMembers = new HashSet<Post>();
            PostReports = new HashSet<PostReport>();
            PostUpDownVotes = new HashSet<PostUpDownVote>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Account { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateTime RegistrationDate { get; set; }
        public string? IconImg { get; set; }
        public bool IsConfirmed { get; set; }
        public string? ConfirmCode { get; set; }
        public bool ActiveFlag { get; set; }
        public DateTime? LastOnlineTime { get; set; }

        public virtual ICollection<BoardsModerator> BoardsModerators { get; set; }
        public virtual ICollection<BoardsModeratorsApplication> BoardsModeratorsApplications { get; set; }
        public virtual ICollection<BucketLog> BucketLogBucketMembers { get; set; }
        public virtual ICollection<BucketLog> BucketLogModeratorMembers { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<GameComment> GameComments { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
        public virtual ICollection<MemberProductView> MemberProductViews { get; set; }
        public virtual ICollection<MembersBoard> MembersBoards { get; set; }
        public virtual ICollection<NewsComment> NewsCommentDeleteMembers { get; set; }
        public virtual ICollection<NewsComment> NewsCommentMembers { get; set; }
        public virtual ICollection<NewsLike> NewsLikes { get; set; }
        public virtual ICollection<NewsView> NewsViews { get; set; }
        public virtual ICollection<NewsletterLog> NewsletterLogs { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<PostComment> PostCommentDeleteMembers { get; set; }
        public virtual ICollection<PostComment> PostCommentMembers { get; set; }
        public virtual ICollection<PostCommentReport> PostCommentReports { get; set; }
        public virtual ICollection<PostCommentUpDownVote> PostCommentUpDownVotes { get; set; }
        public virtual ICollection<Post> PostDeleteMembers { get; set; }
        public virtual ICollection<Post> PostMembers { get; set; }
        public virtual ICollection<PostReport> PostReports { get; set; }
        public virtual ICollection<PostUpDownVote> PostUpDownVotes { get; set; }
    }
}
