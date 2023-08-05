namespace TataGamedomWebAPI.Application.Features.Product.Queries.GetProductTopFiveSalesList;

public class GameDto
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


}