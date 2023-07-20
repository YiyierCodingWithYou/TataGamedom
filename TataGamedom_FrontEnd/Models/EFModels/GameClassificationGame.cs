using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels;

public partial class GameClassificationGame
{
    public int Id { get; set; }

    public int GameId { get; set; }

    public int GameClassificationId { get; set; }

    public virtual Game Game { get; set; } = null!;

    public virtual GameClassificationsCode GameClassification { get; set; } = null!;
}
