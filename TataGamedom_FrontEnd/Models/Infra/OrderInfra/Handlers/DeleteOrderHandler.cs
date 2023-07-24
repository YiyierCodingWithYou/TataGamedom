using MediatR;
using TataGamedom_FrontEnd.Models.EFModels;
using TataGamedom_FrontEnd.Models.Infra.OrderInfra.Commands;
using TataGamedom_FrontEnd.Models.Interfaces;

namespace TataGamedom_FrontEnd.Models.Infra.OrderInfra.Handlers;

public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, int>
{
    private readonly IOrderRepository _orderRepository;

    public DeleteOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<int> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        Order? order = await _orderRepository.GetOrderByIdAsync(request.Id);
        if (order == null)
        {
            return 0;
        }
        else 
        {
            return await _orderRepository.DeleteOrderAsync(request.Id);
        }
    }
}
