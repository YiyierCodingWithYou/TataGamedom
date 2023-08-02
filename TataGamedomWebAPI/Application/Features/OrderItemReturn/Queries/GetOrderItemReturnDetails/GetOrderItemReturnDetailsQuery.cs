using MediatR;

namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Queries.GetOrderItemReturnDetails;

public record GetOrderItemReturnDetailsQuery(int Id) : IRequest<OrderItemReturnDetailsDto>;

