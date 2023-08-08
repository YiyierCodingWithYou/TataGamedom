using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Features.Product.Queries.GetProductTopFiveSalesList;

public class ProductTopFiveSalesDto
{
    public int Id { get; set; }

    public required string GameChiName { get; set; }

    public required string GamePlatformName { get; set; }

    public string GameGameCoverImg { get; set; } = string.Empty;

}
