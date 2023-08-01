using FluentValidation;
using TataGamedomWebAPI.Application.Contracts.Persistence;

namespace TataGamedomWebAPI.Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        private readonly IMemberRepository _memberRepository;

        public CreateOrderCommandValidator(IMemberRepository memberRepository)
        {
            this._memberRepository = memberRepository;

            RuleFor(p => p.MemberId)
            .NotEmpty().WithMessage("{PropertyName} 必填")
            .InclusiveBetween(1, 99999999).WithMessage("{PropertyName}不得小於1")
            .MustAsync(MemberMustExist).WithMessage("該會員不存在");          
            RuleFor(p => p.CreatedAt)
                .NotEmpty().WithMessage("{PropertyName} 必填");

            RuleFor(p => p.ToAddress)
                .NotEmpty().WithMessage("{PropertyName} 必填")
                .Length(0, 50);
        }

        private async Task<bool> MemberMustExist(int memberId, CancellationToken token)
        {
            return await _memberRepository.IsMemberExist(memberId);
        }
    }
}
