using AutoMapper;
using MediatR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Exceptions;
using TataGamedomWebAPI.Infrastructure;

namespace TataGamedomWebAPI.Application.Features.Order.Commands.UpdateOrder;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
{
    //private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly IAppLogger<UpdateOrderCommandHandler> _logger;

    public UpdateOrderCommandHandler(
        //IMapper mapper, 
        IOrderRepository orderRepository, 
        IAppLogger<UpdateOrderCommandHandler> logger)
    {
        //this._mapper = mapper;
        this._orderRepository = orderRepository;
        this._logger = logger;
    }


    public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        await ValidateRequest(request);

        Models.EFModels.Order? orderTobeUpdated = await _orderRepository.GetByIndex(request.Index);
        if (orderTobeUpdated == null) 
        {
            throw new NotFoundException(nameof(orderTobeUpdated),request.Index);
        }

        // 手動映射
        if (request.SentAt.HasValue)
        {
            orderTobeUpdated.SentAt = request.SentAt.Value;
        }

        if (request.DeliveredAt.HasValue)
        {
            orderTobeUpdated.DeliveredAt = request.DeliveredAt.Value;
        }

        if (request.CompletedAt.HasValue)
        {
            orderTobeUpdated.CompletedAt = request.CompletedAt.Value;
        }

        if (!string.IsNullOrEmpty(request.TrackingNum))
        {
            orderTobeUpdated.TrackingNum = request.TrackingNum;
        }

        orderTobeUpdated.OrderStatusId = request.OrderStatusId;

        if (request.ShipmentStatusId.HasValue)
        {
            orderTobeUpdated.ShipmentStatusId = request.ShipmentStatusId.Value;
        }

        orderTobeUpdated.PaymentStatusId = request.PaymentStatusId;

        //orderTobeUpdated = _mapper.Map(request, orderTobeUpdated);

        await _orderRepository.UpdateAsync(orderTobeUpdated);
        _logger.LogInformation("Order were updated successfully");

        return Unit.Value;
    }

    private static async Task ValidateRequest(UpdateOrderCommand request)
    {
        var validator = new UpdateOrderCommandValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid order request", validationResult);
        }
    }
}
