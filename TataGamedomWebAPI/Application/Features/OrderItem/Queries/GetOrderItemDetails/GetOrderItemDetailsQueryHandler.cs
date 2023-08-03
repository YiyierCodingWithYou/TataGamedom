using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderDetails;

namespace TataGamedomWebAPI.Application.Features.OrderItem.Queries.GetOrderItemDetails;

public record GetOrderItemDetailsQueryHandler : IRequestHandler<GetOrderItemDetailsQuery, OrderItemDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly ILogger<GetOrderDetailQueryHandler> _logger;

    public GetOrderItemDetailsQueryHandler(
        IMapper mapper,
        IOrderItemRepository orderItemRepository,
        ILogger<GetOrderDetailQueryHandler> logger)
    {
        this._mapper = mapper;
        this._orderItemRepository = orderItemRepository;
        this._logger = logger;
    }

    public async Task<OrderItemDetailsDto> Handle(GetOrderItemDetailsQuery request, CancellationToken cancellationToken)
    {
        Models.EFModels.OrderItem? orderItemDetail = await _orderItemRepository.GetByIdAsync(request.Id);

        OrderItemDetailsDto response = _mapper.Map<OrderItemDetailsDto>(orderItemDetail);

        _logger.LogInformation("OrderDetail were retrieved successfully");

        return response;
    }
}
