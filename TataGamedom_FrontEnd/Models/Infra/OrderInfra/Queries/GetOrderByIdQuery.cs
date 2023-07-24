using MediatR;
using TataGamedom_FrontEnd.Models.EFModels;

namespace TataGamedom_FrontEnd.Models.Infra.OrderInfra.Queries;

public record GetOrderByIdQuery(int Id) : IRequest<Order>;
