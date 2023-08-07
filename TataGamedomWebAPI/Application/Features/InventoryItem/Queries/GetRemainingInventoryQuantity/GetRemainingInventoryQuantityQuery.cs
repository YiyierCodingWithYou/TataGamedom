using MediatR;
using TataGamedomWebAPI.Application.Features.InventoryItem.Queries.GetRemainingInventoryDetails;
using TataGamedomWebAPI.Application.MappingProfiles;

namespace TataGamedomWebAPI.Application.Features.InventoryItem.Queries.GetRemainingInventoryQuantity;

public record GetRemainingInventoryQuantityQuery(int ProductId) : IRequest<int>;
