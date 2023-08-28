using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Exceptions;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Features.Order.Commands.DeleteCarts;

public class DeleteCartsCommandHandler : IRequestHandler<DeleteCartsCommand, Unit>
{
    private readonly ICartRepository _cartRepository;
    private readonly IAppLogger<DeleteCartsCommandHandler> _logger;

    public DeleteCartsCommandHandler(ICartRepository cartRepository, IAppLogger<DeleteCartsCommandHandler> logger)
    {
        this._cartRepository = cartRepository;
        this._logger = logger;
    }

    public async Task<Unit> Handle(DeleteCartsCommand request, CancellationToken cancellationToken)
    {
        List<Cart>? cart = await _cartRepository.GetCartListByMemberIdAsync(request.MemberId);
        if (cart?.Any() == false)
        {
            _logger.LogWarning("購物車不存在");
            throw new NotFoundException(nameof(cart), request.MemberId);
        }
        await _cartRepository.DeleteAsync(cart!);

        _logger.LogInformation("購物車已清空");
        return Unit.Value;

    }
}
