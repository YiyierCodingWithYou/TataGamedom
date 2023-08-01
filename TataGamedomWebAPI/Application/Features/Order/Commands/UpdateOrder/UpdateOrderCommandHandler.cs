using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Features.Order.Commands.UpdateOrder;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly IApperLogger<UpdateOrderCommandHandler> _logger;

    public UpdateOrderCommandHandler(
        IMapper mapper, 
        IOrderRepository orderRepository, 
        IApperLogger<UpdateOrderCommandHandler> logger)
    {
        this._mapper = mapper;
        this._orderRepository = orderRepository;
        this._logger = logger;
    }


    public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var orderTobeUpdated = await _orderRepository.GetByIdAsync(request.Id);

        orderTobeUpdated = _mapper.Map(request, orderTobeUpdated);

        await _orderRepository.UpdateAsync(orderTobeUpdated);

        _logger.LogInformation("Order were updated successfully");

        return Unit.Value;
    }
}
