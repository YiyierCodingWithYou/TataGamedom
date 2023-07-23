using MediatR;
using TataGamedom_FrontEnd.Models.EFModels;
using TataGamedom_FrontEnd.Models.Interfaces;

namespace TataGamedom_FrontEnd.Models.Infra.Order.Create;

public class CreateOrderComandHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderComandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new EFModels.Order 
        {
            
        };
    }
}
