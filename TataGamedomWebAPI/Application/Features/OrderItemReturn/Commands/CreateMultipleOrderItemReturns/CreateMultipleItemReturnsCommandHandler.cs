using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Exceptions;
using TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.CreateOrderItemReturn;
using TataGamedomWebAPI.Application.Features.OrderItemReturn.Queries.GetOrderItemReturnList;
using TataGamedomWebAPI.Models.EFModels;
using TataGamedomWebAPI.Models.Interfaces;

namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.CreateMultipleOrderItemReturns;

public class CreateMultipleItemReturnsCommandHandler : IRequestHandler<CreateMultipleItemReturnsCommand, List<OrderItemReturnDto>>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IOrderItemReturnRepository _orderItemReturnRepository;
    private readonly IIndexGenerator _indexGenerator;
    private readonly IAppLogger<CreateMultipleItemReturnsCommandHandler> _logger;

    public CreateMultipleItemReturnsCommandHandler(
        IMapper mapper,
        IOrderRepository orderRepository,
        IOrderItemRepository orderItemRepository,
        IOrderItemReturnRepository orderItemReturnRepository,
        IIndexGenerator indexGenerator,
        IAppLogger<CreateMultipleItemReturnsCommandHandler> logger
        )
    {
        this._mapper = mapper;
        this._orderRepository = orderRepository;
        this._orderItemRepository = orderItemRepository;
        this._orderItemReturnRepository = orderItemReturnRepository;
        this._indexGenerator = indexGenerator;
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

        return _mapper.Map<List<OrderItemReturnDto>>(orderItemReturnToBeCreatedList);        
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