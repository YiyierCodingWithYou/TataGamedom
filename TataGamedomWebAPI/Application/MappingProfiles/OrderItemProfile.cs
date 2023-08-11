using AutoMapper;
using TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateMultipleOrderItems;
using TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateOrderItem;
using TataGamedomWebAPI.Application.Features.OrderItem.Queries.GetOrderItemDetails;
using TataGamedomWebAPI.Application.Features.OrderItem.Queries.GetOrderItemList;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.MappingProfiles;

public class OrderItemProfile : Profile
{
    public OrderItemProfile()
    {
        CreateMap<OrderItem, OrderItemDto>();
        CreateMap<OrderItem, OrderItemDetailsDto>();
        CreateMap<CreateOrderItemCommand, OrderItem>();
        CreateMap<OrderItem, CreateOrderItemResponseDto>().ReverseMap();
    }
}
