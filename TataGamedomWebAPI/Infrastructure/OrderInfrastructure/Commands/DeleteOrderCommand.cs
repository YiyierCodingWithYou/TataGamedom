using MediatR;

namespace TataGamedomWebAPI.Infrastructure.OrderInfrastructure.Commands;

public record DeleteOrderCommand(int Id) : IRequest<int>;
