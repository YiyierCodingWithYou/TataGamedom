using FluentValidation;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateOrderItem;

public class CreateOrderItemCommandValidator : AbstractValidator<CreateOrderItemCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IInventoryItemRepository _inventoryItemRepository;

    public CreateOrderItemCommandValidator(
        IOrderRepository orderRepository,
        IProductRepository productRepository,
        IInventoryItemRepository inventoryItemRepository)
    {
        this._orderRepository = orderRepository;
        this._productRepository = productRepository;
        this._inventoryItemRepository = inventoryItemRepository;

        RuleFor(p => p.OrderId)
            .NotEmpty()
            .MustAsync(OrderMustExist)
            .WithMessage("訂單主檔不存在");


        RuleFor(p => p.InventoryItemId)
            .NotEmpty()
            .MustAsync(InventoryItemMustExist).WithMessage("此庫存編號不存在")
            .MustAsync(InventoryItemMustNotSold).WithMessage("此庫存商品已售出");


    }

    private async Task<bool> InventoryItemMustNotSold(int inventoryItemId, CancellationToken token)
    {
        return await _inventoryItemRepository.IsInventoryItemNotSoldOut(inventoryItemId);
    }

    private async Task<bool> InventoryItemMustExist(int inventoryItemId, CancellationToken token)
    {
        return await _inventoryItemRepository.IsInventoryItemExist(inventoryItemId);
    }

    private async Task<bool> ProductMustExist(int productId, CancellationToken token)
    {
        return await _productRepository.IsProductExist(productId);
    }

    private async Task<bool> OrderMustExist(int orderId, CancellationToken token)
    {
        return await _orderRepository.IsOrderExist(orderId);
    }
}
