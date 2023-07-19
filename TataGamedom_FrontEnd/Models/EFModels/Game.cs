using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels
{
    public partial class Game
    {
        public Game()
        {
            Boards = new HashSet<Board>();
            GameClassificationGames = new HashSet<GameClassificationGame>();
            GameComments = new HashSet<GameComment>();
            News = new HashSet<News>();
            Products = new HashSet<Product>();
        }

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

        public virtual BackendMember CreatedBackendMember { get; set; } = null!;
        public virtual BackendMember? ModifiedBackendMember { get; set; }
        public virtual ICollection<Board> Boards { get; set; }
        public virtual ICollection<GameClassificationGame> GameClassificationGames { get; set; }
        public virtual ICollection<GameComment> GameComments { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
