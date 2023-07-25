using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class GameClassificationsCode
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<GameClassificationGame> GameClassificationGames { get; set; } = new List<GameClassificationGame>();
}
