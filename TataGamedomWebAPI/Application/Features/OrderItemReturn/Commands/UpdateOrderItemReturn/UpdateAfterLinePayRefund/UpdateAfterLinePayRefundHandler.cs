using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Exceptions;

namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.UpdateOrderItemReturn.UpdateAfterLinePayRefund;

public class UpdateAfterLinePayRefundHandler : IRequestHandler<UpdateAfterLinePayRefundDto, Unit>
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

    public async Task<Unit> Handle(UpdateAfterLinePayRefundDto request, CancellationToken cancellationToken)
    {

        await _orderItemReturnRepository.UpdatePartialAsync(request);

        _logger.LogInformation("第三方金流退款資訊已新增至退貨單，並更改狀態為已退款");

        return Unit.Value;

    }
}
