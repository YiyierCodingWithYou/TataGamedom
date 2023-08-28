using MediatR;

namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Queries.GetOrderItemReturnListByOrderId;

public record GetOrderItemReturnListByOrderIdQuery(int OrderId) : IRequest<List<OrderItemReturnDto>>;

