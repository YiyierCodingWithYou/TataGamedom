using MediatR;
using TataGamedom_FrontEnd.Models.EFModels;
using TataGamedom_FrontEnd.Models.Infra.OrderInfra.Queries;
using TataGamedom_FrontEnd.Models.Interfaces;

namespace TataGamedom_FrontEnd.Models.Infra.OrderInfra.Handlers;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Order?>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByIdHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken) 
        
        => await _orderRepository.GetOrderByIdAsync(request.Id);
}
