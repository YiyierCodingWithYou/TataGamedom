using MediatR;

namespace TataGamedomWebAPI.Application.Features.OrderItem.Queries.GetOrderItemDetails;

public record GetOrderItemDetailsQuery(int Id) : IRequest<OrderItemDetailsDto>;
