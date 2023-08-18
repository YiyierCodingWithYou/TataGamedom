using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;

namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Queries.GetOrderItemReturnListByOrderId;

public class GetOrderItemReturnListQueryByOrderIdHandler : IRequestHandler<GetOrderItemReturnListByOrderIdQuery, List<int>>
{
    private readonly IOrderItemReturnRepository _orderItemReturnRepository;
    private readonly IAppLogger<GetOrderItemReturnListQueryByOrderIdHandler> _logger;

    public GetOrderItemReturnListQueryByOrderIdHandler(
        IOrderItemReturnRepository orderItemReturnRepository,
        IAppLogger<GetOrderItemReturnListQueryByOrderIdHandler> logger)
    {
        this._orderItemReturnRepository = orderItemReturnRepository;
        this._logger = logger;
    }

    public async Task<List<int>> Handle(GetOrderItemReturnListByOrderIdQuery request, CancellationToken cancellationToken)
    {
        List<int> orderItemIdList = await _orderItemReturnRepository.GetOrderItemIdList(request.OrderId);
        
        _logger.LogInformation("orderItemId list was retreive successfully");
        return orderItemIdList;
    }
}
