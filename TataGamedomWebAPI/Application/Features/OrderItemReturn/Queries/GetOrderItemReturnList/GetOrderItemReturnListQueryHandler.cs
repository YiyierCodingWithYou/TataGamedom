using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;

namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Queries.GetOrderItemReturnList;

public class GetOrderItemReturnListQueryHandler : IRequestHandler<GetOrderItemReturnListQuery, List<OrderItemReturnDto>>
{
    private readonly IMapper _mapper;
    private readonly IOrderItemReturnRepository _orderItemReturnRepository;
    private readonly IAppLogger<GetOrderItemReturnListQueryHandler> _logger;

    public GetOrderItemReturnListQueryHandler(
        IMapper mapper,
        IOrderItemReturnRepository orderItemReturnRepository,
        IAppLogger<GetOrderItemReturnListQueryHandler> logger)
    {
        this._mapper = mapper;
        this._orderItemReturnRepository = orderItemReturnRepository;
        this._logger = logger;
    }
    public async Task<List<OrderItemReturnDto>> Handle(GetOrderItemReturnListQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<Models.EFModels.OrderItemReturn> orderItemReturn = await _orderItemReturnRepository.GetListIncludeOrderItemAsync();

        List<OrderItemReturnDto> response =  _mapper.Map<List<OrderItemReturnDto>>(orderItemReturn);

        _logger.LogInformation("orderItemReturn list were retrieved successfully");
        return response;
    }
}
