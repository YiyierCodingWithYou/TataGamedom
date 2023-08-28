using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;

namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Queries.GetOrderItemReturnListByOrderId;

public class GetOrderItemReturnListQueryByOrderIdHandler : IRequestHandler<GetOrderItemReturnListByOrderIdQuery, List<OrderItemReturnDto>>
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

    public async Task<List<OrderItemReturnDto>> Handle(GetOrderItemReturnListByOrderIdQuery request, CancellationToken cancellationToken)
    {

        List<OrderItemReturnDto> orderItemList = await _orderItemReturnRepository.GetListByOrderId(request.OrderId);

        _logger.LogInformation("已根據訂單編號取得對應退貨單資訊");
        return orderItemList;
    }
}
