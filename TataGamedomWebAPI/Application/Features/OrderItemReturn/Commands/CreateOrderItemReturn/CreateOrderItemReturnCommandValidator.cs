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
