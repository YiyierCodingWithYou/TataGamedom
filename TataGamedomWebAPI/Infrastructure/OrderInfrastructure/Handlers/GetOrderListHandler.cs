﻿using MediatR;
using TataGamedom_FrontEnd.Models.Infra.OrderInfra.Queries;
using TataGamedom_FrontEnd.Models.Interfaces;
using TataGamedomWebAPI.Models.Dtos;
using TataGamedomWebAPI.Models.EFModels;

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
