using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Exceptions;

namespace TataGamedomWebAPI.Application.Features.Order.Commands.UpdateOrder.UpdateLinePayInfo;

public class UpdateLinePayInfoCommandHandler : IRequestHandler<UpdateLinePayInfoCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly IAppLogger<UpdateLinePayInfoCommandHandler> _logger;

    public UpdateLinePayInfoCommandHandler(
        IMapper mapper,
        IOrderRepository orderRepository,
        IAppLogger<UpdateLinePayInfoCommandHandler> logger)
    {
        this._mapper = mapper;
        this._orderRepository = orderRepository;
        this._logger = logger;
    }

    public async Task<Unit> Handle(UpdateLinePayInfoCommand request, CancellationToken cancellationToken)
    {
        Models.EFModels.Order? orderTobeUpdated = await _orderRepository.GetByIndex(request.Index);
        if (orderTobeUpdated == null)
        {
            throw new NotFoundException(nameof(orderTobeUpdated), request.Index);
        }

        orderTobeUpdated = _mapper.Map(request, orderTobeUpdated);
        await _orderRepository.UpdateAsync(orderTobeUpdated!);

        _logger.LogInformation("LinePay付款資訊已新增至訂單");

        return Unit.Value;

    }
}
