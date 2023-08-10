using MediatR;

namespace TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderListByAccount;

public record GetOrderListByAccountQuery() : IRequest<List<OrderWithDeatilsDto>>;
