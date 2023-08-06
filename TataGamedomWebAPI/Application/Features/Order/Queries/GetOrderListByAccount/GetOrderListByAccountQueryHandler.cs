using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Features.Product.Queries.GetProductTopFiveSalesList;

namespace TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderListByAccount;

public class GetOrderListByAccountQueryHandler : IRequestHandler<GetOrderListByAccountQuery, List<OrderWithDeatilsDto>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IAppLogger<GetOrderListByAccountQueryHandler> _logger;

    public GetOrderListByAccountQueryHandler(
        IOrderRepository orderRepository,
        IAppLogger<GetOrderListByAccountQueryHandler> logger)
    {
        this._orderRepository = orderRepository;
        this._logger = logger;
    }

    public async Task<List<OrderWithDeatilsDto>> Handle(GetOrderListByAccountQuery request, CancellationToken cancellationToken)
    {
        List<OrderWithDeatilsDto> response = await _orderRepository.GetOrderWithDetailsByAccount(request.Account);
      
        _logger.LogInformation("This user's order list with deatils were retrived successfully");
        return response;

    }
}
