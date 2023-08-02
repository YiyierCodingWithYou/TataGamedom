using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Features.OrderItem.Queries.GetOrderItemList;

namespace TataGamedomWebAPI.Application.Features.OrderItemItem.Queries.GetOrderItemItemList;

public class GetOrderItemListQueryHandler : IRequestHandler<GetOrderItemListQuery, List<OrderItemDto>>
{
    private readonly IMapper _mapper;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IApperLogger<GetOrderItemListQueryHandler> _logger;

    public GetOrderItemListQueryHandler(
        IMapper mapper,
        IOrderItemRepository orderItemRepository,
        IApperLogger<GetOrderItemListQueryHandler> logger)
    {
        this._mapper = mapper;
        this._orderItemRepository = orderItemRepository;
        this._logger = logger;
    }

    public async Task<List<OrderItemDto>> Handle(GetOrderItemListQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<Models.EFModels.OrderItem> orderItem = await _orderItemRepository.GetListAsync();

        List<OrderItemDto> response = _mapper.Map<List<OrderItemDto>>(orderItem);

        _logger.LogInformation("OrderItems were retrieved successfully");

        return response;
    }
}