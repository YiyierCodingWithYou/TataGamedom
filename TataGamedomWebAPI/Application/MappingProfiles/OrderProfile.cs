using AutoMapper;
using TataGamedomWebAPI.Application.Features.Order.Commands.CreateOrder;
using TataGamedomWebAPI.Application.Features.Order.Commands.UpdateOrder;
using TataGamedomWebAPI.Application.Features.Order.Commands.UpdateOrder.UpdateLinePayInfo;
using TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderDetails;
using TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderList;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.MappingProfiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>();

        CreateMap<Order, OrderDetailsDto>();

        CreateMap<CreateOrderCommand, Order>();

        CreateMap<UpdateOrderCommand, Order>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<UpdateLinePayInfoCommand, Order>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());  
    }
}
