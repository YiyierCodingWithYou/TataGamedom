using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class News
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public int BackendMemberId { get; set; }

    public int NewsCategoryId { get; set; }

    public int? GamesId { get; set; }

    public string? CoverImg { get; set; }

    public DateTime ScheduleDate { get; set; }

    public bool ActiveFlag { get; set; }

    public DateTime? EditDatetime { get; set; }

    public DateTime? DeleteDatetime { get; set; }

    public int? DeleteBackendMemberId { get; set; }

    public virtual BackendMember BackendMember { get; set; } = null!;

    public virtual BackendMember? DeleteBackendMember { get; set; }

    public virtual Game? Games { get; set; }

    public virtual NewsCategoryCode NewsCategory { get; set; } = null!;

    public virtual ICollection<NewsComment> NewsComments { get; set; } = new List<NewsComment>();

    public virtual ICollection<NewsLike> NewsLikes { get; set; } = new List<NewsLike>();

    public virtual ICollection<NewsView> NewsViews { get; set; } = new List<NewsView>();
}
