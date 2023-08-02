using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Exceptions;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateOrderItem;

public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IProductRepository _productRepository;
    private readonly IInventoryItemRepository _inventoryItemRepository;
    private readonly IAppLogger<CreateOrderItemCommandHandler> _logger;

    public CreateOrderItemCommandHandler(
        IMapper mapper,
        IOrderRepository orderRepository,
        IOrderItemRepository orderItemRepository,
        IProductRepository productRepository,
        IInventoryItemRepository inventoryItemRepository,
        IAppLogger<CreateOrderItemCommandHandler> logger)
    {
        this._mapper = mapper;
        this._orderRepository = orderRepository;
        this._orderItemRepository = orderItemRepository;
        this._productRepository = productRepository;
        this._inventoryItemRepository = inventoryItemRepository;
        this._logger = logger;
    }

    public async Task<int> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
        await ValidateRequestAsync(request);

        var orderItemTobeCreated = _mapper.Map<Models.EFModels.OrderItem>(request);
        await _orderItemRepository.CreateAsync(orderItemTobeCreated);

        _logger.LogInformation("Created successfully");
        return orderItemTobeCreated.Id;
    }

    private async Task ValidateRequestAsync(CreateOrderItemCommand request)
    {
        var validator = new CreateOrderItemCommandValidator(
                    _orderRepository,
                    _productRepository,
                    _inventoryItemRepository);

        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid orderItem request", validationResult);
        }
    }
}
