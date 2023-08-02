using MediatR;

namespace TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderList;

public record GetOrderListQuery : IRequest<List<OrderDto>>;
