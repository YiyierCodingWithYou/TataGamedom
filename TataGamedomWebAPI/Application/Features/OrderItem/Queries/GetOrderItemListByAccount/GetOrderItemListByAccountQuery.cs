using MediatR;

namespace TataGamedomWebAPI.Application.Features.OrderItem.Queries.GetOrderItemListByAccount;

public record GetOrderItemListByOrderIdQuery(int orderId) : IRequest<List<OrderItemWithDetailsDto>>;
