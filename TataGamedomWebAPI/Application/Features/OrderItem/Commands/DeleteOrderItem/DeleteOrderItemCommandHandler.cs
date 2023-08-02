using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Exceptions;

namespace TataGamedomWebAPI.Application.Features.OrderItem.Commands.DeleteOrderItem;

public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand, Unit>
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IAppLogger<DeleteOrderItemCommandHandler> _logger;

    public DeleteOrderItemCommandHandler(
        IOrderItemRepository orderItemRepository, 
        IAppLogger<DeleteOrderItemCommandHandler> logger)
    {
        this._orderItemRepository = orderItemRepository;
        this._logger = logger;
    }

    public async Task<Unit> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
    {
        var orderItemTobeDeleted = await _orderItemRepository.GetByIdAsync(request.Id);
        if (orderItemTobeDeleted == null)
        {
            throw new NotFoundException(nameof(orderItemTobeDeleted), request.Id);
        }

        await _orderItemRepository.DeleteAsync(orderItemTobeDeleted);
        
        _logger.LogInformation("OrderItem were deleted successfully");
        
        return Unit.Value;

    }
}
