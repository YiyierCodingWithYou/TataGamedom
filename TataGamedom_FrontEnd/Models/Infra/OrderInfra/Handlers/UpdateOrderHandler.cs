using MediatR;
using TataGamedom_FrontEnd.Models.EFModels;
using TataGamedom_FrontEnd.Models.Infra.OrderInfra.Commands;
using TataGamedom_FrontEnd.Models.Interfaces;

namespace TataGamedom_FrontEnd.Models.Infra.OrderInfra.Handlers;

public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, int>
{
    private readonly IOrderRepository _orderRepository;

    public UpdateOrderHandler(IOrderRepository orderRepository )
    {
        _orderRepository = orderRepository;
    }

    public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        Order? order = await _orderRepository.GetOrderByIdAsync(request.Id);
        if (order == null)
        {
            return 0;
        }
        else 
        {
            order.OrderStatusId = request.OrderStatusId;
            order.ShipmentStatusId = request.ShipmentStatusId;
            order.PaymentStatusId = request.PaymentStatusId;
            order.CompletedAt = request.CompletedAt;
            order.ShipmemtMethodId = request.ShipmemtMethodId;
            order.RecipientName = request.RecipientName;
            order.ToAddress = request.ToAddress;
            order.SentAt = request.SentAt;
            order.DeliveredAt = request.DeliveredAt;
            order.TrackingNum = request.TrackingNum;

            return await _orderRepository.UpdateOrderAsync(order);
        }
    }
}
