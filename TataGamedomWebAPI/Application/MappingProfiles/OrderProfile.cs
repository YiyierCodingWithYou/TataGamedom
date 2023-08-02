using AutoMapper;
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
    }
}
