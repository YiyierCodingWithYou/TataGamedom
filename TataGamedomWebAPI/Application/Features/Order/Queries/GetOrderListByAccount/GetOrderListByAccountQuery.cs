using MediatR;

namespace TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderListByAccount;

public record GetOrderListByAccountQuery(string Account) : IRequest<List<OrderWithDeatilsDto>>;
