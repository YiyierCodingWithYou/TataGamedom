using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Exceptions;
using TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderDetails;
using TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateMultipleOrderItems;
using TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateOrderItem;
using TataGamedomWebAPI.Application.Features.OrderItem.Queries.GetOrderItemList;
using TataGamedomWebAPI.Application.Features.OrderItem.Queries.GetOrderItemListByAccount;
using TataGamedomWebAPI.Infrastructure;
using TataGamedomWebAPI.Models.EFModels;
using TataGamedomWebAPI.Models.Interfaces;

namespace TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateMultipleItemsWithOrderId;

public class CreateMultipleItemsWithOrderIdCommandHandler : IRequestHandler<CreateMultipleItemsWithOrderIdCommand, List<CreateOrderItemResponseDto>>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IProductRepository _productRepository;
    private readonly IInventoryItemRepository _inventoryItemRepository;
	private readonly ICartRepository _cartRepository;
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
		this._cartRepository = cartRepository;
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
        await DeleteCart(request);

        _logger.LogInformation("Created multiple order items successfully");

        return _mapper.Map<List<CreateOrderItemResponseDto>>(orderItemToBeCreatedList);
    }

    private async Task DeleteCart(CreateMultipleItemsWithOrderIdCommand request)
	{
        List<Cart>? cart = await _cartRepository.GetCartListByMemberIdAsync(request.CreateOrderCommand.MemberId);
		if (cart?.Any() == false)
		{
			_logger.LogWarning("購物車不存在");
			throw new NotFoundException(nameof(cart), request.CreateOrderCommand.MemberId);
		}
		await _cartRepository.DeleteAsync(cart!);
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


