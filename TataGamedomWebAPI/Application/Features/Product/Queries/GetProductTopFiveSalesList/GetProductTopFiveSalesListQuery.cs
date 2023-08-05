using MediatR;

namespace TataGamedomWebAPI.Application.Features.Product.Queries.GetProductTopFiveSalesList;

public record GetProductTopFiveSalesListQuery : IRequest<List<ProductTopFiveSalesDto>>;
