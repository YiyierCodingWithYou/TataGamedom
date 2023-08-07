using AutoMapper;
using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;

namespace TataGamedomWebAPI.Application.Features.InventoryItem.Queries.GetInventoryItemDetails;

public class GetInventoryItemDetailsQueryHandler : IRequestHandler<GetInventoryItemDetailsQuery, InventoryItemDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IInventoryItemRepository _inventoryItemRepository;
    private readonly IAppLogger<GetInventoryItemDetailsQueryHandler> _logger;

    public GetInventoryItemDetailsQueryHandler(
        IMapper mapper,
        IInventoryItemRepository inventoryItemRepository,
        IAppLogger<GetInventoryItemDetailsQueryHandler> logger)
    {
        this._mapper = mapper;
        this._inventoryItemRepository = inventoryItemRepository;
        this._logger = logger;
    }

    public async Task<InventoryItemDetailsDto> Handle(GetInventoryItemDetailsQuery request, CancellationToken cancellationToken)
    {
        Models.EFModels.InventoryItem? inventoryItems = await _inventoryItemRepository.GetByIdAsync(request.Id);
        var response = _mapper.Map<InventoryItemDetailsDto>(inventoryItems);

        _logger.LogInformation("InventoryItemDetails were retrieved successfully");
        return response;
    }
}
