using MediatR;

namespace TataGamedomWebAPI.Application.Features.InventoryItem.Queries.GetInventoryItemDetails;

public record GetInventoryItemDetailsQuery(int Id) : IRequest<InventoryItemDetailsDto>;
