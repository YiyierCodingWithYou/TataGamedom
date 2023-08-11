using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;

namespace TataGamedomWebAPI.Application.Features.InventoryItem.Queries.GetRemainingInventoryList;

public class GetRemaingItemIdListByProductIdQueryHandler : IRequestHandler<GetRemaingItemIdListByProductIdQuery, List<int>>
{
    private readonly IInventoryItemRepository _inventoryItemRepository;
    private readonly IAppLogger<GetRemaingItemIdListByProductIdQueryHandler> _logger;

    public GetRemaingItemIdListByProductIdQueryHandler(
        IInventoryItemRepository inventoryItemRepository,
        IAppLogger<GetRemaingItemIdListByProductIdQueryHandler> logger)
    {
        this._inventoryItemRepository = inventoryItemRepository;
        this._logger = logger;
    }

    public async Task<List<int>> Handle(GetRemaingItemIdListByProductIdQuery request, CancellationToken cancellationToken)
    {
        List<int> remaingItemIdList = await _inventoryItemRepository.GetRemaingItemIdListByProductId(request.ProductId);
        _logger.LogInformation("Remaing inventoryItem Ids were retrieved successfully");
        return remaingItemIdList;
    }
}
