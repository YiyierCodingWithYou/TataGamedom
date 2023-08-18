using FluentValidation;
using TataGamedomWebAPI.Application.Contracts.Persistence;

namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.CreateOrderItemReturn;

public class CreateOrderItemReturnCommandValidator : AbstractValidator<CreateOrderItemReturnCommand>
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IOrderItemReturnRepository _orderItemReturnRepository;

    public CreateOrderItemReturnCommandValidator(
        IOrderItemRepository orderItemRepository,
        IOrderItemReturnRepository orderItemReturnRepository)
    {
        this._orderItemRepository = orderItemRepository;
        this._orderItemReturnRepository = orderItemReturnRepository;


        RuleFor(p => p.OrderItemId)
            .NotEmpty()
            .MustAsync(OrderItemMustExist)
            .WithMessage("此訂單品項不存在");

        RuleFor(p => p.OrderItemId)
            .NotEmpty()
            .MustAsync(OrderItemMustUnique)
            .WithMessage("此品項已有退貨紀錄");

        RuleFor(p => p.OrderItemId)
            .NotEmpty()
            .MustAsync(OrderStatusIsCompletedOrReturned)
            .WithMessage("訂單狀態須為'已完成'或'退貨程序處理中'才能退貨");

    }

    private async Task<bool> OrderStatusIsCompletedOrReturned(int orderItemId, CancellationToken token)
    {
        return await _orderItemReturnRepository.IsStatusCompletedOrReturned(orderItemId);
    }

    private async Task<bool> OrderItemMustUnique(int orderItemId, CancellationToken token)
    {
        return await _orderItemReturnRepository.IsReturnOrderExist(orderItemId) == false;
    }

    private async Task<bool> OrderItemMustExist(int orderItemId, CancellationToken token)
    {
        return await _orderItemRepository.IsOrderItemExist(orderItemId);
    }
}
