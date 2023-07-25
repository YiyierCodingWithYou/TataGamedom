using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class BoardsModerator
{
    public int Id { get; set; }

    public int ModeratorMemberId { get; set; }

    public int BoardId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Board Board { get; set; } = null!;

    public virtual Member ModeratorMember { get; set; } = null!;
}
