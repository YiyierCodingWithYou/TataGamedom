using FluentValidation;
namespace TataGamedomWebAPI.Application.Features.Order.Shared;

public class BaseOrderValidator : AbstractValidator<BaseOrder>
{
    public BaseOrderValidator()
    {
        RuleFor(p => p.OrderStatusId)
            .NotEmpty().WithMessage("{PropertyName} 必填")
            .InclusiveBetween(1, 4);

        RuleFor(p => p.ShipmentStatusId)
            .NotEmpty().WithMessage("{PropertyName} 必填")
            .InclusiveBetween(1, 7);

        RuleFor(p => p.PaymentStatusId)
            .NotEmpty().WithMessage("{PropertyName} 必填")
            .InclusiveBetween(1, 5);

        RuleFor(p => p.ShipmemtMethodId)
            .NotEmpty().WithMessage("{PropertyName} 必填")
            .InclusiveBetween(1, 6);

        RuleFor(p => p.RecipientName)
            .NotEmpty().WithMessage("{PropertyName} 必填")
            .Length(0, 20);

    }
}
