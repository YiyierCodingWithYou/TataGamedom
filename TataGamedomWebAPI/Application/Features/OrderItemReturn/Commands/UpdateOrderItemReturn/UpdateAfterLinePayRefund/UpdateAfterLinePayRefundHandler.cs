using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Exceptions;

namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.UpdateOrderItemReturn.UpdateAfterLinePayRefund;

public class UpdateAfterLinePayRefundHandler : IRequestHandler<UpdateAfterLinePayRefund, Unit>
{
    private readonly IMapper _mapper;
    private readonly IOrderItemReturnRepository _orderItemReturnRepository;
    private readonly IAppLogger<UpdateAfterLinePayRefundHandler> _logger;

    public UpdateAfterLinePayRefundHandler(
        IMapper mapper,
        IOrderItemReturnRepository orderItemReturnRepository,
        IAppLogger<UpdateAfterLinePayRefundHandler> logger)
    {
        this._mapper = mapper;
        this._orderItemReturnRepository = orderItemReturnRepository;
        this._logger = logger;
    }

    public async Task<Unit> Handle(UpdateAfterLinePayRefund request, CancellationToken cancellationToken)
    {
        var orderItemReturnToBeUpdated = await _orderItemReturnRepository.GetByIdAsync(request.Id);
        if (orderItemReturnToBeUpdated == null) 
        {
            throw new NotFoundException(nameof(orderItemReturnToBeUpdated), request.Id);
        }
        orderItemReturnToBeUpdated = _mapper.Map(request, orderItemReturnToBeUpdated);
        await _orderItemReturnRepository.UpdateAsync(orderItemReturnToBeUpdated);

        _logger.LogInformation("LinePay退款資訊已新增至訂單");

        return Unit.Value;

    }
}
