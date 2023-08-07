using MediatR;

namespace TataGamedomWebAPI.Application.Features.InventoryItem.Queries.GetInventoryItemList;

public record GetInventoryItemQuery : IRequest<List<InventoryItemDto>>;
