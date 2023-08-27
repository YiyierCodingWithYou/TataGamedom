using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.PaymentService;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Exceptions;
using TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.CreateOrderItemReturn;
using TataGamedomWebAPI.Application.Features.OrderItemReturn.Queries.GetOrderItemReturnList;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.PaymentRefund;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Response.PaymentRefund;
using TataGamedomWebAPI.Models.Interfaces;

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

    public CreateMultipleItemReturnsCommandHandler(
        IMapper mapper,
        IOrderRepository orderRepository,
        IOrderItemRepository orderItemRepository,
        IOrderItemReturnRepository orderItemReturnRepository,
        IIndexGenerator indexGenerator,
        ILinePayService linePayService,
        IAppLogger<CreateMultipleItemReturnsCommandHandler> logger
        )
    {
        this._mapper = mapper;
        this._orderRepository = orderRepository;
        this._orderItemRepository = orderItemRepository;
        this._orderItemReturnRepository = orderItemReturnRepository;
        this._indexGenerator = indexGenerator;
        this._linePayService = linePayService;
        this._logger = logger;
    }

    public async Task<List<OrderItemReturnDto>> Handle(CreateMultipleItemReturnsCommand request, CancellationToken cancellationToken)
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

        _logger.LogInformation("Created multiple items to return successfully");

        List<OrderItemReturnDto> orderItemReturnList = _mapper.Map<List<OrderItemReturnDto>>(orderItemReturnToBeCreatedList);

        await CallLinePayRefundAPI(orderItemReturnList);

        return orderItemReturnList;
    }

    private async Task CallLinePayRefundAPI(List<OrderItemReturnDto> orderItemReturnList)
    {
        //todo 如果是實體商品，要已退貨才能退款

        int orderItemId = orderItemReturnList.First().OrderItemId;
        Models.EFModels.OrderItem? orderItem = await _orderItemRepository.GetByIdAsync(orderItemId);
        string? linePayTransitionId = await _orderRepository.GetLinePayTransitionId(orderItem?.OrderId);

        if (linePayTransitionId != null)
        {
            decimal refundAmount = 0;
            foreach (var item in orderItemReturnList)
            {
                refundAmount += await _orderItemRepository.GetPriceById(item.OrderItemId);
            }

            PaymentRefundResponseDto response = await _linePayService.RefundPayment(linePayTransitionId, new PaymentRefundRequestDto { RefundAmount = (int)refundAmount });
            _logger.LogInformation(
                $"LinePay退款，交易編號{linePayTransitionId}，" +
                $"執行結果{response.ReturnMessage}，" +
                $"退款時間{response.Info.RefundTransactionDate}，" +
                $"退款編號{response.Info.RefundTransactionId}");

            // todo update該退貨品項成已退款，如果退款失敗，顯示待退款
        };
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
}