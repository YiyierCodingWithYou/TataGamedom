using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateMultipleOrderItems;
using TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateOrderItem;
using TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence.Repositories;
using TataGamedomWebAPI.Models.Interfaces;

namespace TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateMultipleItemsWithOrderId;

public class CreateMultipleItemsWithOrderIdCommandHandler : IRequestHandler<CreateMultipleItemsWithOrderIdCommand, List<CreateOrderItemResponseDto>>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IProductRepository _productRepository;
    private readonly IInventoryItemRepository _inventoryItemRepository;
	private readonly IAppLogger<CreateMultipleItemsWithOrderIdCommandHandler> _logger;
    private readonly IIndexGenerator _indexGenerator;
    private readonly IMediator _mediator;

    public CreateMultipleItemsWithOrderIdCommandHandler(
        IMapper mapper,
        IOrderRepository orderRepository,
        IOrderItemRepository orderItemRepository,
        IProductRepository productRepository,
        IInventoryItemRepository inventoryItemRepository,
        ICartRepository cartRepository,
        IAppLogger<CreateMultipleItemsWithOrderIdCommandHandler> logger,
        IIndexGenerator indexGenerator,
        IMediator mediator)
    {
        this._mapper = mapper;
        this._orderRepository = orderRepository;
        this._orderItemRepository = orderItemRepository;
        this._productRepository = productRepository;
        this._inventoryItemRepository = inventoryItemRepository;
		this._logger = logger;
        this._indexGenerator = indexGenerator;
        this._mediator = mediator;
    }

    public async Task<List<CreateOrderItemResponseDto>> Handle(CreateMultipleItemsWithOrderIdCommand request, CancellationToken cancellationToken)
    {
        var orderItemToBeCreatedList = new List<Models.EFModels.OrderItem>();
        HashSet<int> soldOutIds = await _inventoryItemRepository.GetSoldOutIdList();

        int responseOrderId = await _mediator.Send(request.CreateOrderCommand);

        foreach (var createOrderItemCommand in request.CreateOrderItemCommandList)
        {   
            var orderItem = _mapper.Map<Models.EFModels.OrderItem>(createOrderItemCommand);

            orderItem.OrderId = responseOrderId;

            await AddInventoryIemIdToOrderItem(soldOutIds, createOrderItemCommand, orderItem);

            await GenerateIndex(createOrderItemCommand, orderItem);
            orderItemToBeCreatedList.Add(orderItem);
        }

        await _orderItemRepository.CreateAsync(orderItemToBeCreatedList);

        //如果皆為虛擬，updateOrder為已完成
        if (await _productRepository.AreAllOrderItemsVirtual(orderItemToBeCreatedList)) 
        {
            await _orderRepository.UpdateOrderStatusIfAllItemsVirtual(responseOrderId);
        }

        _logger.LogInformation("Created multiple order items successfully");

        return _mapper.Map<List<CreateOrderItemResponseDto>>(orderItemToBeCreatedList);
    }


	private async Task AddInventoryIemIdToOrderItem(HashSet<int> soldOutIds, CreateOrderItemCommand createOrderItemCommand, Models.EFModels.OrderItem orderItem)
    {
        int remainingInventoryId = await _inventoryItemRepository.GetRemainingInventoryId(createOrderItemCommand.ProductId, soldOutIds);
        orderItem.InventoryItemId = remainingInventoryId;

        soldOutIds.Add(remainingInventoryId);
    }

    private async Task GenerateIndex(CreateOrderItemCommand request, Models.EFModels.OrderItem orderItemTobeCreated)
    {
        int maxOrderItemId = await _orderItemRepository.GetMaxId();
        string productIndex = await _productRepository.GetIndexById(request.ProductId);
        orderItemTobeCreated.Index = _indexGenerator.GetOrderItemIndex(productIndex, orderItemTobeCreated, maxOrderItemId);
    }
}


