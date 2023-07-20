using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels;

public partial class Game
{
    public int Id { get; set; }

    public string ChiName { get; set; } = null!;

    public string EngName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsRestrict { get; set; }

    public string GameCoverImg { get; set; } = null!;

    public DateTime CreatedTime { get; set; }

    public int CreatedBackendMemberId { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public int? ModifiedBackendMemberId { get; set; }

    public virtual ICollection<Board> Boards { get; set; } = new List<Board>();

    public virtual BackendMember CreatedBackendMember { get; set; } = null!;

    public virtual ICollection<GameClassificationGame> GameClassificationGames { get; set; } = new List<GameClassificationGame>();

    public virtual ICollection<GameComment> GameComments { get; set; } = new List<GameComment>();

    public virtual BackendMember? ModifiedBackendMember { get; set; }

    public virtual ICollection<News> News { get; set; } = new List<News>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
