using MediatR;

namespace TataGamedomWebAPI.Application.Features.OrderItem.Queries.GetOrderItemListByAccount;

public record GetOrderItemListByOrderIdQuery(int OrderId) : IRequest<List<OrderItemWithDetailsDto>>;
