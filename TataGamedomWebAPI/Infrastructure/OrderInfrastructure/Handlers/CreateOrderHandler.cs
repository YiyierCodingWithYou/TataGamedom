using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using TataGamedom_FrontEnd.Models.Interfaces;
using TataGamedomWebAPI.Infrastructure.OrderInfrastructure.Commands;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedom_FrontEnd.Models.Infra.OrderInfra.Handlers;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Order>
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    { 
        Order order = new Order 
        {
            //To do : Index
            MemberId = request.MemberId,
            OrderStatusId = request.OrderStatusId,
            ShipmentStatusId = request.ShipmentStatusId,
            PaymentStatusId = request.PaymentStatusId,
            CreatedAt = DateTime.Now,
            ShipmemtMethodId = request.ShipmemtMethodId,
            RecipientName = request.RecipientName!,
            ToAddress = request.ToAddress!
        };
        return await _orderRepository.AddOrderAsync(order);
    }
}
