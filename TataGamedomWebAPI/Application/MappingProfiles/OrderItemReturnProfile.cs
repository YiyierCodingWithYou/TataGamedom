using AutoMapper;
using TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.CreateOrderItemReturn;
using TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.UpdateOrderItemReturn;
using TataGamedomWebAPI.Application.Features.OrderItemReturn.Queries.GetOrderItemReturnDetails;
using TataGamedomWebAPI.Application.Features.OrderItemReturn.Queries.GetOrderItemReturnList;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.MappingProfiles;

public class OrderItemReturnProfile : Profile
{
    public OrderItemReturnProfile()
    {
        CreateMap<OrderItemReturn, OrderItemReturnDto>();
        CreateMap<OrderItemReturn, OrderItemReturnDetailsDto>();
        CreateMap<CreateOrderItemReturnCommand, OrderItemReturn>();
        CreateMap<UpdateOrderItemReturnCommand, OrderItemReturn>();
    }
}
