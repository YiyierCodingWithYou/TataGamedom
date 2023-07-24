using MediatR;
using TataGamedom_FrontEnd.Models.EFModels;
using TataGamedom_FrontEnd.Models.Infra.OrderInfra.Queries;
using TataGamedom_FrontEnd.Models.Interfaces;

namespace TataGamedom_FrontEnd.Models.Infra.OrderInfra.Handlers;

public class GetOrderListHandler : IRequestHandler<GetOrderListQuery, IEnumerable<Order>>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderListHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<Order>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
    
        => await _orderRepository.GetOrderListAsync();

}
