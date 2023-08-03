using MediatR;

namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Queries.GetOrderItemReturnList;

public record GetOrderItemReturnListQuery : IRequest<List<OrderItemReturnDto>>;
