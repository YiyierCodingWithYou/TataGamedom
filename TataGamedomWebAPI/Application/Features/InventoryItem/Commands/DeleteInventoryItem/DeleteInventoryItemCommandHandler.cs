using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Exceptions;

namespace TataGamedomWebAPI.Application.Features.InventoryItem.Commands.DeleteInventoryItem;

public class DeleteInventoryItemCommandHandler : IRequestHandler<DeleteInventoryItemCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IInventoryItemRepository _inventoryItemRepository;
    private readonly IAppLogger<DeleteInventoryItemCommandHandler> _logger;

    public DeleteInventoryItemCommandHandler(
        IMapper mapper,
        IInventoryItemRepository inventoryItemRepository,
        IAppLogger<DeleteInventoryItemCommandHandler> logger)
    {
        this._mapper = mapper;
        this._inventoryItemRepository = inventoryItemRepository;
        this._logger = logger;
    }

    public async Task<Unit> Handle(DeleteInventoryItemCommand request, CancellationToken cancellationToken)
    {
        Models.EFModels.InventoryItem? inventoryItem = await _inventoryItemRepository.GetByIdAsync(request.Id);
        if (inventoryItem == null) 
        {
            throw new NotFoundException(nameof(inventoryItem), request.Id);
        }

        await _inventoryItemRepository.DeleteAsync(inventoryItem);
        return Unit.Value;
    }
}
