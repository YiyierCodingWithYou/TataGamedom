using MediatR;

namespace TataGamedomWebAPI.Application.Features.InventoryItem.Queries.GetRemainingInventoryList;

public record GetRemaingItemIdListByProductIdQuery(int ProductId) : IRequest<List<int>>;
