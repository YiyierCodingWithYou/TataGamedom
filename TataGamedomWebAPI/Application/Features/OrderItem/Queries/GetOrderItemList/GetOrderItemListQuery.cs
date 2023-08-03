using MediatR;

namespace TataGamedomWebAPI.Application.Features.OrderItem.Queries.GetOrderItemList;

public record GetOrderItemListQuery : IRequest<List<OrderItemDto>>;

