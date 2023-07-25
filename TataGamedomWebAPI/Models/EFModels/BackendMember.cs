using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class BackendMember
{
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

    public virtual ICollection<Board> Boards { get; set; } = new List<Board>();

    public virtual ICollection<BoardsModeratorsApplication> BoardsModeratorsApplications { get; set; } = new List<BoardsModeratorsApplication>();

    public virtual ICollection<BucketLog> BucketLogs { get; set; } = new List<BucketLog>();

    public virtual ICollection<Coupon> CouponCreatedBackendMembers { get; set; } = new List<Coupon>();

    public virtual ICollection<Coupon> CouponModifiedBackendMembers { get; set; } = new List<Coupon>();

    public virtual ICollection<GameComment> GameComments { get; set; } = new List<GameComment>();

    public virtual ICollection<Game> GameCreatedBackendMembers { get; set; } = new List<Game>();

    public virtual ICollection<Game> GameModifiedBackendMembers { get; set; } = new List<Game>();

    public virtual ICollection<News> NewsBackendMembers { get; set; } = new List<News>();

    public virtual ICollection<NewsComment> NewsComments { get; set; } = new List<NewsComment>();

    public virtual ICollection<News> NewsDeleteBackendMembers { get; set; } = new List<News>();

    public virtual ICollection<Newsletter> Newsletters { get; set; } = new List<Newsletter>();

    public virtual ICollection<PostCommentReport> PostCommentReports { get; set; } = new List<PostCommentReport>();

    public virtual ICollection<PostComment> PostComments { get; set; } = new List<PostComment>();

    public virtual ICollection<PostReport> PostReports { get; set; } = new List<PostReport>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Product> ProductCreatedBackendMembers { get; set; } = new List<Product>();

    public virtual ICollection<Product> ProductModifiedBackendMembers { get; set; } = new List<Product>();

    public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();
}
