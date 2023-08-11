using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Exceptions;
using TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateOrderItem;
using TataGamedomWebAPI.Models.EFModels;
using TataGamedomWebAPI.Models.Interfaces;

namespace TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateMultipleOrderItems;

public class CreateMultipleOrderItemsCommandHandler : IRequestHandler<CreateMultipleOrderItemsCommand, List<Models.EFModels.OrderItem>>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IProductRepository _productRepository;
    private readonly IInventoryItemRepository _inventoryItemRepository;
    private readonly IAppLogger<CreateOrderItemCommandHandler> _logger;
    private readonly IIndexGenerator _indexGenerator;

    public CreateMultipleOrderItemsCommandHandler(
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

    /// <summary>
    /// 取得未售出庫存Id => 於迴圈賦值並紀錄已加入的Id => 驗證 => mapping => 產生自訂編號 => 一次新增多筆明細
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<Models.EFModels.OrderItem>> Handle(CreateMultipleOrderItemsCommand request, CancellationToken cancellationToken)
    {
        var orderItemToBeCreatedList = new List<Models.EFModels.OrderItem>();
        HashSet<int> soldOutIds = await _inventoryItemRepository.GetSoldOutIdList();

        foreach (var createOrderItemCommand in request.CreateOrderItemCommandList)
        {
            await AddInventoryIemIdToOrderItem(soldOutIds, createOrderItemCommand);

            await ValidateRequestAsync(createOrderItemCommand);

            var orderItem = _mapper.Map<Models.EFModels.OrderItem>(createOrderItemCommand);

            await GenerateIndex(createOrderItemCommand, orderItem);

            orderItemToBeCreatedList.Add(orderItem);
        }

        await _orderItemRepository.CreateAsync(orderItemToBeCreatedList);
        _logger.LogInformation("Created multiple order items successfully");
        return orderItemToBeCreatedList;
    }

    private async Task AddInventoryIemIdToOrderItem(HashSet<int> soldOutIds, CreateOrderItemCommand createOrderItemCommand)
    {
        int remainingInventoryId = await _inventoryItemRepository.GetRemainingInventoryId(createOrderItemCommand.ProductId, soldOutIds);
        createOrderItemCommand.InventoryItemId = remainingInventoryId;
        
        soldOutIds.Add(remainingInventoryId);
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
