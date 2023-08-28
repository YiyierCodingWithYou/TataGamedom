using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Exceptions;

namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.UpdateOrderItemReturn;

public class UpdateOrderItemReturnCommandHandler : IRequestHandler<UpdateOrderItemReturnCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IOrderItemReturnRepository _orderItemReturnRepository;
    private readonly IAppLogger<UpdateOrderItemReturnCommandHandler> _logger;

    public UpdateOrderItemReturnCommandHandler(
        IMapper mapper,
        IOrderItemReturnRepository orderItemReturnRepository,
        IAppLogger<UpdateOrderItemReturnCommandHandler> logger)
    {
        this._mapper = mapper;
        this._orderItemReturnRepository = orderItemReturnRepository;
        this._logger = logger;
    }

    public async Task<Unit> Handle(UpdateOrderItemReturnCommand request, CancellationToken cancellationToken)
    {
        await ValidateRequest(request);

        if (request.IsReturned && request.IsRefunded)
        {
            request.CompletedAt = DateTime.Now;
        }

        Models.EFModels.OrderItemReturn? orderItemReturnToBeUpdated = await _orderItemReturnRepository.GetByIdAsync(request.Id);
        
        orderItemReturnToBeUpdated = _mapper.Map(request, orderItemReturnToBeUpdated);
        await _orderItemReturnRepository.UpdateAsync(orderItemReturnToBeUpdated);
        return Unit.Value;
    }

    private static async Task ValidateRequest(UpdateOrderItemReturnCommand request)
    {
        var validator = new UpdateOrderItemReturnCommandValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid OrderItemReturn request", validationResult);
        }
    }
}
