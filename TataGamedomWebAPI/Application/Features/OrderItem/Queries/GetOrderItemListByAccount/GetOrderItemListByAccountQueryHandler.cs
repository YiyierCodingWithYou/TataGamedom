using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;

namespace TataGamedomWebAPI.Application.Features.OrderItem.Queries.GetOrderItemListByAccount;

public class GetOrderItemListByOrderIdQueryHandler : IRequestHandler<GetOrderItemListByOrderIdQuery, List<OrderItemWithDetailsDto>>
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IAppLogger<GetOrderItemListByOrderIdQueryHandler> _logger;

    public GetOrderItemListByOrderIdQueryHandler(
        IOrderItemRepository orderItemRepository,
        IAppLogger<GetOrderItemListByOrderIdQueryHandler> logger)
    {
        this._orderItemRepository = orderItemRepository;
        this._logger = logger;
    }

    public async Task<List<OrderItemWithDetailsDto>> Handle(GetOrderItemListByOrderIdQuery request, CancellationToken cancellationToken)
    {
        List<OrderItemWithDetailsDto> response = await _orderItemRepository.GetListByAccountWithDetailsAsync(request.orderId);
        
        foreach (var orderItem in response) 
        {
            string template = string.Empty;
            template = orderItem.GameGameCoverImg;
            orderItem.GameGameCoverImg = "https://localhost:7081/Files/Uploads/" + template;
        }

        _logger.LogInformation("OrderItemList was retrived succcessfully");
        return response;
    }
}
