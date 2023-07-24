using MediatR;

namespace TataGamedom_FrontEnd.Models.Infra.OrderInfra.Commands;

public record DeleteOrderCommand(int Id) : IRequest<int>;
