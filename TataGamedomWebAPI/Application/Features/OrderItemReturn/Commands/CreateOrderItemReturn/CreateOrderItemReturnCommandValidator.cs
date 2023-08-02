using FluentValidation;
using TataGamedomWebAPI.Application.Contracts.Persistence;

namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.CreateOrderItemReturn;

public class CreateOrderItemReturnCommandValidator : AbstractValidator<CreateOrderItemReturnCommand>
{
    private readonly IOrderItemRepository _orderItemRepository;

    public CreateOrderItemReturnCommandValidator(IOrderItemRepository orderItemRepository)
    {
        this._orderItemRepository = orderItemRepository;

        RuleFor(p => p.OrderItemId)
            .NotEmpty()
            .MustAsync(OrderItemMustExist)
            .WithMessage("此訂單品項不存在");
        
    }

    private async Task<bool> OrderItemMustExist(int orderItemId, CancellationToken token)
    {
        return await _orderItemRepository.IsOrderItemExist(orderItemId);
    }
}
