using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Exceptions;
using TataGamedomWebAPI.Models.EFModels;
using TataGamedomWebAPI.Models.Interfaces;

namespace TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateOrderItem;

public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IProductRepository _productRepository;
    private readonly IInventoryItemRepository _inventoryItemRepository;
    private readonly IAppLogger<CreateOrderItemCommandHandler> _logger;
    private readonly IIndexGenerator _indexGenerator;

    public CreateOrderItemCommandHandler(
        IMapper mapper,
        IOrderRepository orderRepository,
        IOrderItemRepository orderItemRepository,
        IProductRepository productRepository,
        IInventoryItemRepository inventoryItemRepository,
        IAppLogger<CreateOrderItemCommandHandler> logger,
        IIndexGenerator indexGenerator)
    {
        this._mapper = mapper;
        this._orderRepository = orderRepository;
        this._orderItemRepository = orderItemRepository;
        this._productRepository = productRepository;
        this._inventoryItemRepository = inventoryItemRepository;
        this._logger = logger;
        this._indexGenerator = indexGenerator;
    }

    public async Task<int> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
        request.InventoryItemId = await _inventoryItemRepository.GetRemainingInventoryId(request.ProductId);
        await ValidateRequestAsync(request);

        Models.EFModels.OrderItem orderItemTobeCreated = _mapper.Map<Models.EFModels.OrderItem>(request);

        await GenerateIndex(request, orderItemTobeCreated);
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
    
    private async Task GenerateIndex(CreateOrderItemCommand request, Models.EFModels.OrderItem orderItemTobeCreated)
    {
        int maxOrderItemId = await _orderItemRepository.GetMaxId();
        orderItemTobeCreated.Index = _indexGenerator.GetOrderItemIndex(orderItemTobeCreated, maxOrderItemId);
    }
}
