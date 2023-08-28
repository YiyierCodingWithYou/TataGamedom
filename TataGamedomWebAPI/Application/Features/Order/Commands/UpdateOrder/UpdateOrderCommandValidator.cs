using FluentValidation;
namespace TataGamedomWebAPI.Application.Features.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(p => p.Index)
                .NotEmpty()
                .WithMessage("{PropertyName} 必填");
            
        }
    }
}
