using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;

namespace TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderList;

public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, List<OrderDto>>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly IAppLogger<GetOrderListQueryHandler> _logger;

    public GetOrderListQueryHandler(
        IMapper mapper, 
        IOrderRepository orderRepository,
        IAppLogger<GetOrderListQueryHandler> logger)
    {
        this._mapper = mapper;
        this._orderRepository = orderRepository;
        this._logger = logger;
    }

    public async Task<List<OrderDto>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<Models.EFModels.Order> order = await _orderRepository.GetListAsync();

        var response = _mapper.Map<List<OrderDto>>(order);

        _logger.LogInformation("Orders were retrieved successfully");

        return response;
    }
}
