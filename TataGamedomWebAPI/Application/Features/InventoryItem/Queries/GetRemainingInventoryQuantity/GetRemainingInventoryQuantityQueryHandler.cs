using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Features.InventoryItem.Queries.GetRemainingInventoryDetails;

namespace TataGamedomWebAPI.Application.Features.InventoryItem.Queries.GetRemainingInventoryQuantity;

public class GetRemainingInventoryQuantityQueryHandler : IRequestHandler<GetRemainingInventoryQuantityQuery, int>
{
    private readonly IInventoryItemRepository _inventoryItemRepository;
    private readonly IAppLogger<GetRemainingInventoryQuantityQueryHandler> _logger;

    public GetRemainingInventoryQuantityQueryHandler(
        IInventoryItemRepository inventoryItemRepository,
        IAppLogger<GetRemainingInventoryQuantityQueryHandler> logger)
    {
        this._inventoryItemRepository = inventoryItemRepository;
        this._logger = logger;
    }


    public async Task<int> Handle(GetRemainingInventoryQuantityQuery request, CancellationToken cancellationToken)
    {
        int remaininginventoryQuantity = await _inventoryItemRepository.GetRemainingInventoryQuantity(request.ProductId);

        _logger.LogInformation("RemainingInventoryQuantity was retrieved successfully");
        return remaininginventoryQuantity;
    }
}
