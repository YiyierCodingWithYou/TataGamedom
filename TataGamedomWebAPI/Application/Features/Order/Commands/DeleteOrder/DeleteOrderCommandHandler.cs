using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Exceptions;

namespace TataGamedomWebAPI.Application.Features.Order.Commands.DeleteOrder;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IAppLogger<DeleteOrderCommandHandler> _logger;

    public DeleteOrderCommandHandler(IOrderRepository orderRepository, IAppLogger<DeleteOrderCommandHandler> logger)
    {
        this._orderRepository = orderRepository;
        this._logger = logger;
    }
    public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var orderToBeDeleted = await _orderRepository.GetByIdAsync(request.Id);

        ValidateRequest(request, orderToBeDeleted);

        await _orderRepository.DeleteAsync(orderToBeDeleted!);
        _logger.LogInformation("Order were deleted successfully");
        return Unit.Value;
    }

    private static void ValidateRequest(DeleteOrderCommand request, Models.EFModels.Order? orderToBeDeleted)
    {
        if (orderToBeDeleted == null)
        {
            throw new NotFoundException(nameof(orderToBeDeleted), request.Id);
        }
    }
}
