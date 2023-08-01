using MediatR;

namespace TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderDetails;

public record GetOrderDetailQuery(int Id): IRequest<OrderDetailDto>;
