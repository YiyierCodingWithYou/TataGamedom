using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Exceptions;

namespace TataGamedomWebAPI.Application.Features.Order.Commands.DeleteOrder;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IApperLogger<DeleteOrderCommandHandler> _logger;

    public DeleteOrderCommandHandler(IOrderRepository orderRepository, IApperLogger<DeleteOrderCommandHandler> logger)
    {
        this._orderRepository = orderRepository;
        this._logger = logger;
    }
    public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var orderToBeDeleted = await _orderRepository.GetByIdAsync(request.Id);
        if (orderToBeDeleted == null) 
        {
            throw new NotFoundException(nameof(orderToBeDeleted), request.Id);
        }

        await _orderRepository.DeleteAsync(orderToBeDeleted);
        _logger.LogInformation("Order were deleted successfully");
        return Unit.Value;
    }
}
