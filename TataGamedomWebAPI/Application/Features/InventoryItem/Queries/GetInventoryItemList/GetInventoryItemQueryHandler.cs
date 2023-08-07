using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;

namespace TataGamedomWebAPI.Application.Features.InventoryItem.Queries.GetInventoryItemList;

public class GetInventoryItemQueryHandler : IRequestHandler<GetInventoryItemQuery, List<InventoryItemDto>>
{
    private readonly IMapper _mapper;
    private readonly IInventoryItemRepository _inventoryItemRepository;
    private readonly IAppLogger<GetInventoryItemQueryHandler> _logger;

    public GetInventoryItemQueryHandler(
        IMapper mapper,
        IInventoryItemRepository inventoryItemRepository,
        IAppLogger<GetInventoryItemQueryHandler> logger)
    {
        this._mapper = mapper;
        this._inventoryItemRepository = inventoryItemRepository;
        this._logger = logger;
    }

    public async Task<List<InventoryItemDto>> Handle(GetInventoryItemQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<Models.EFModels.InventoryItem> inventoryItems = await _inventoryItemRepository.GetListAsync();
        var response = _mapper.Map<List<InventoryItemDto>>(inventoryItems);

        _logger.LogInformation("InventoryItems were retrieved successfully");
        return response;
    }
}
