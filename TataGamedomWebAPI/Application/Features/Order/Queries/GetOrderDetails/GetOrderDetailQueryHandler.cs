using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Persistence;

namespace TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderDetails;

public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, OrderDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly ILogger<GetOrderDetailQueryHandler> _logger;

    public GetOrderDetailQueryHandler(
        IMapper mapper, 
        IOrderRepository orderRepository, 
        ILogger<GetOrderDetailQueryHandler> logger)
    {
        this._mapper = mapper;
        this._orderRepository = orderRepository;
        this._logger = logger;
    }

    public async Task<OrderDetailsDto> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
    {
        var orderDetail = await _orderRepository.GetByIdAsync(request.Id);
        
        var response = _mapper.Map<OrderDetailsDto>(orderDetail);

        _logger.LogInformation("OrderDetail were retrieved successfully");

        return response;
    }
}

