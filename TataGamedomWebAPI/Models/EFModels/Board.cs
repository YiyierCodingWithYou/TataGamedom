using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class Board
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? GameId { get; set; }

    public string? BoardAbout { get; set; }

    public string? BoardHeaderCoverImg { get; set; }

    public DateTime CreatedTime { get; set; }

    public int CreatedBackendMemberId { get; set; }

    public virtual ICollection<BoardsModerator> BoardsModerators { get; set; } = new List<BoardsModerator>();

    public virtual ICollection<BoardsModeratorsApplication> BoardsModeratorsApplications { get; set; } = new List<BoardsModeratorsApplication>();

    public virtual ICollection<BucketLog> BucketLogs { get; set; } = new List<BucketLog>();

    public virtual BackendMember CreatedBackendMember { get; set; } = null!;

    public virtual Game? Game { get; set; }

    public virtual ICollection<MembersBoard> MembersBoards { get; set; } = new List<MembersBoard>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
