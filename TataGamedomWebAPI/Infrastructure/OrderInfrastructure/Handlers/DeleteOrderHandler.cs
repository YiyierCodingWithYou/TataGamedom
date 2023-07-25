using MediatR;
using TataGamedom_FrontEnd.Models.Interfaces;
using TataGamedomWebAPI.Infrastructure.OrderInfrastructure.Commands;
using TataGamedomWebAPI.Models.EFModels;

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
