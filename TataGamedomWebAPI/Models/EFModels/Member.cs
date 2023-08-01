using System;
using System.Collections.Generic;
using TataGamedomWebAPI.Models.Common;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class Member : BaseEntity
{
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

    public virtual ICollection<BoardsModerator> BoardsModerators { get; set; } = new List<BoardsModerator>();

    public virtual ICollection<BoardsModeratorsApplication> BoardsModeratorsApplications { get; set; } = new List<BoardsModeratorsApplication>();

    public virtual ICollection<BucketLog> BucketLogBucketMembers { get; set; } = new List<BucketLog>();

    public virtual ICollection<BucketLog> BucketLogModeratorMembers { get; set; } = new List<BucketLog>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<GameComment> GameComments { get; set; } = new List<GameComment>();

    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();

    public virtual ICollection<MemberProductView> MemberProductViews { get; set; } = new List<MemberProductView>();

    public virtual ICollection<MembersBoard> MembersBoards { get; set; } = new List<MembersBoard>();

    public virtual ICollection<NewsComment> NewsCommentDeleteMembers { get; set; } = new List<NewsComment>();

    public virtual ICollection<NewsComment> NewsCommentMembers { get; set; } = new List<NewsComment>();

    public virtual ICollection<NewsLike> NewsLikes { get; set; } = new List<NewsLike>();

    public virtual ICollection<NewsView> NewsViews { get; set; } = new List<NewsView>();

    public virtual ICollection<NewsletterLog> NewsletterLogs { get; set; } = new List<NewsletterLog>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<PostComment> PostCommentDeleteMembers { get; set; } = new List<PostComment>();

    public virtual ICollection<PostComment> PostCommentMembers { get; set; } = new List<PostComment>();

    public virtual ICollection<PostCommentReport> PostCommentReports { get; set; } = new List<PostCommentReport>();

    public virtual ICollection<PostCommentUpDownVote> PostCommentUpDownVotes { get; set; } = new List<PostCommentUpDownVote>();

    public virtual ICollection<Post> PostDeleteMembers { get; set; } = new List<Post>();

    public virtual ICollection<Post> PostMembers { get; set; } = new List<Post>();

    public virtual ICollection<PostReport> PostReports { get; set; } = new List<PostReport>();

    public virtual ICollection<PostUpDownVote> PostUpDownVotes { get; set; } = new List<PostUpDownVote>();
}
