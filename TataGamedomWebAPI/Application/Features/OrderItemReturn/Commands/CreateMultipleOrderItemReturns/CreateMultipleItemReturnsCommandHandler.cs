using AutoMapper;
using Azure;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.PaymentService;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Exceptions;
using TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.CreateOrderItemReturn;
using TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.UpdateOrderItemReturn.UpdateAfterLinePayRefund;
using TataGamedomWebAPI.Application.Features.OrderItemReturn.Queries.GetOrderItemReturnList;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.PaymentRefund;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Response.PaymentRefund;
using TataGamedomWebAPI.Models.Interfaces;
using static Google.Apis.Requests.BatchRequest;

namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.CreateMultipleOrderItemReturns;

public class CreateMultipleItemReturnsCommandHandler : IRequestHandler<CreateMultipleItemReturnsCommand, List<OrderItemReturnDto>>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IOrderItemReturnRepository _orderItemReturnRepository;
    private readonly IIndexGenerator _indexGenerator;
    private readonly ILinePayService _linePayService;
    private readonly IAppLogger<CreateMultipleItemReturnsCommandHandler> _logger;
    private readonly IMediator _mediator;

    public CreateMultipleItemReturnsCommandHandler(
        IMapper mapper,
        IOrderRepository orderRepository,
        IOrderItemRepository orderItemRepository,
        IOrderItemReturnRepository orderItemReturnRepository,
        IIndexGenerator indexGenerator,
        ILinePayService linePayService,
        IAppLogger<CreateMultipleItemReturnsCommandHandler> logger,
        IMediator mediator
        )
    {
        this._mapper = mapper;
        this._orderRepository = orderRepository;
        this._orderItemRepository = orderItemRepository;
        this._orderItemReturnRepository = orderItemReturnRepository;
        this._indexGenerator = indexGenerator;
        this._linePayService = linePayService;
        this._logger = logger;
        this._mediator = mediator;
    }

    public async Task<List<OrderItemReturnDto>> Handle(CreateMultipleItemReturnsCommand request, CancellationToken cancellationToken)
    {
        List<Models.EFModels.OrderItemReturn> orderItemReturnToBeCreatedList = await CreateMutipleOrderItemReturnToDb(request);

        List<OrderItemReturnDto> orderItemReturnList = _mapper.Map<List<OrderItemReturnDto>>(orderItemReturnToBeCreatedList);
        
        await RefundByThirdParty(orderItemReturnList);

        return orderItemReturnList;
    }


    private async Task<List<Models.EFModels.OrderItemReturn>> CreateMutipleOrderItemReturnToDb(CreateMultipleItemReturnsCommand request)
    {
        var validator = new CreateOrderItemReturnCommandValidator(_orderItemRepository, _orderItemReturnRepository);
        var orderItemReturnToBeCreatedList = new List<Models.EFModels.OrderItemReturn>();

        foreach (var command in request.CreateOrderItemReturnCommandList)
        {
            await ValidatCommand(validator, command);

            var orderItemReturn = _mapper.Map<Models.EFModels.OrderItemReturn>(command);
            await GenerateIndex(orderItemReturn);

            orderItemReturnToBeCreatedList.Add(orderItemReturn);
        }

        await _orderItemReturnRepository.CreateAsync(orderItemReturnToBeCreatedList);
        await _orderRepository.UpdateOrderStatusAfterReturn(request.CreateOrderItemReturnCommandList.FirstOrDefault()!.OrderItemId);

        _logger.LogInformation("(單筆/多筆)退貨單建立成功");
        return orderItemReturnToBeCreatedList;
    }

    private async Task GenerateIndex(Models.EFModels.OrderItemReturn orderItemReturn)
    {
        string? orderIndex = await _orderItemRepository.GetOrderIndexById(orderItemReturn.OrderItemId);
        int maxId = await _orderItemReturnRepository.GetMaxId();
        orderItemReturn.Index = _indexGenerator.GetOrderItemReturnIndex(orderItemReturn, orderIndex!, maxId);
    }

    private static async Task ValidatCommand(CreateOrderItemReturnCommandValidator validator, CreateOrderItemReturnCommand command)
    {
        var validateResult = await validator.ValidateAsync(command);
        if (validateResult.Errors.Any())
        {
            throw new BadRequestException("Invalid OrderItemReturn request", validateResult);
        }
    }

    private async Task RefundByThirdParty(List<OrderItemReturnDto> orderItemReturnList)
    {
        //目前皆執行LinePay退款並更新狀態，若新增其他金流退款需拆開
        decimal refundAmount = await GetRefundTotal(orderItemReturnList);
        PaymentRefundResponseDto? response = await ExcuteLinePayRefund(orderItemReturnList, refundAmount);
        await UpdateRefundStatusAndTransactionId(orderItemReturnList, response);
    }

    private async Task<decimal> GetRefundTotal(List<OrderItemReturnDto> orderItemReturnList)
    {
        decimal refundAmount = 0;
        foreach (var item in orderItemReturnList)
        {
            refundAmount += await _orderItemRepository.GetPriceById(item.OrderItemId);
        }

        return refundAmount;
    }

    private async Task<PaymentRefundResponseDto?> ExcuteLinePayRefund(List<OrderItemReturnDto> orderItemReturnList, decimal refundAmount)
    {
        var orderItem = await _orderItemRepository.GetByIdAsync(orderItemReturnList.First().OrderItemId);

        string? linePayTransitionId = await _orderRepository.GetLinePayTransitionId(orderItem?.OrderId);

        if (linePayTransitionId != null) 
        {
            PaymentRefundResponseDto response = await _linePayService.RefundPayment(linePayTransitionId, new PaymentRefundRequestDto { RefundAmount = (int)refundAmount });

            _logger.LogInformation(
                $"LinePay退款，交易編號{linePayTransitionId}，" +
                $"執行結果{response.ReturnMessage}，" +
                $"退款時間{response.Info.RefundTransactionDate}，" +
                $"退款編號{response.Info.RefundTransactionId}");
            return response;
        }
        return null;
    }

    private async Task UpdateRefundStatusAndTransactionId(List<OrderItemReturnDto> orderItemReturnList, PaymentRefundResponseDto? response)
    {
        // todo update 該退貨品項成已退款並加入退款序號，如果退款失敗，顯示待退款
        // todo 退款單狀態 => 如果皆為虛擬且退款成功 => 已完成   ; 如果有實體 => 退款處理中 => 退貨完成 => 退款 => 已完成

        foreach (var orderItemReturn in orderItemReturnList)
        {
            await _mediator.Send(new UpdateAfterLinePayRefund
            {
                Id = orderItemReturn.Id,
                IsRefunded = true,
                CompletedAt = DateTime.Now,
                LinePayRefundTransactionId = response?.Info.RefundTransactionId.ToString(),
                //如果其他第三方支付也有退款編號，加在這裡
            });
        }
    }
}
