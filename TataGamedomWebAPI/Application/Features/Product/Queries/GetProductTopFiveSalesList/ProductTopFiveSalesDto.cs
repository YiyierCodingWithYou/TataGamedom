using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Features.Product.Queries.GetProductTopFiveSalesList;

public class ProductTopFiveSalesDto
{
    public int Id { get; set; }

    public required GameDto Game { get; set; }

    public required GamePlatformsCodeDto GamePlatformsCode { get; set; }

}
