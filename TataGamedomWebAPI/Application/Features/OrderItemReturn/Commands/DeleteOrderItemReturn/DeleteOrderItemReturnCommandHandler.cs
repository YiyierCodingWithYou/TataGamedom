using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Exceptions;

namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.DeleteOrderItemReturn;

public class DeleteOrderItemReturnCommandHandler : IRequestHandler<DeleteOrderItemReturnCommand, Unit>
{
    private readonly IOrderItemReturnRepository _orderItemReturnRepository;
    private readonly IAppLogger<DeleteOrderItemReturnCommandHandler> _logger;

    public DeleteOrderItemReturnCommandHandler(
        IOrderItemReturnRepository orderItemReturnRepository,
        IAppLogger<DeleteOrderItemReturnCommandHandler> logger)
    {
        this._orderItemReturnRepository = orderItemReturnRepository;
        this._logger = logger;
    }

    public async Task<Unit> Handle(DeleteOrderItemReturnCommand request, CancellationToken cancellationToken)
    {
        var orderTobeDeleted = await _orderItemReturnRepository.GetByIdAsync(request.Id);
        if (orderTobeDeleted == null) 
        {
            throw new NotFoundException(nameof(orderTobeDeleted), request.Id);
        }

        await _orderItemReturnRepository.DeleteAsync(orderTobeDeleted);

        _logger.LogInformation("OrderItemReturn was deleted successfully");
        return Unit.Value;
    }
}