using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels
{
    public partial class GameClassificationsCode
    {
        public GameClassificationsCode()
        {
            GameClassificationGames = new HashSet<GameClassificationGame>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<GameClassificationGame> GameClassificationGames { get; set; }
    }
}
