using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;

namespace TataGamedomWebAPI.Application.Features.Product.Queries.GetProductTopFiveSalesList;

public class GetProductTopFiveSalesListQueryHandler : IRequestHandler<GetProductTopFiveSalesListQuery, List<ProductTopFiveSalesDto>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly IAppLogger<GetProductTopFiveSalesListQueryHandler> _logger;

    public GetProductTopFiveSalesListQueryHandler(
        IMapper mapper,
        IProductRepository productRepository,
        IAppLogger<GetProductTopFiveSalesListQueryHandler> logger)
    {
        this._mapper = mapper;
        this._productRepository = productRepository;
        this._logger = logger;
    }

    public async Task<List<ProductTopFiveSalesDto>> Handle(GetProductTopFiveSalesListQuery request, CancellationToken cancellationToken)
    {
        List<Models.EFModels.Product> productTopFiveSalesList = await _productRepository.GetProductTopFiveSalesWithDetails();
        var response = _mapper.Map<List<ProductTopFiveSalesDto>>(productTopFiveSalesList);

        _logger.LogInformation("ProductTopFiveSalesList were retrived successfully");
        return response;
    }
}
