using FluentValidation;
namespace TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.UpdateOrderItemReturn;

public class UpdateOrderItemReturnCommandValidator : AbstractValidator<UpdateOrderItemReturnCommand>
{
    public UpdateOrderItemReturnCommandValidator()
    {
        RuleFor(p => p.CompletedAt)
            .Empty()
            .When(p => !(p.IsRefunded && p.IsReturned))
            .WithMessage("完成時間會在退貨及退款皆完成時自動建立");

        RuleFor(p => p.IsResellable)
            .Equal(false)
            .When(p => !(p.IsRefunded && p.IsReturned))
            .WithMessage("退貨及退款皆完成才能更改重新上架");

    }
}
