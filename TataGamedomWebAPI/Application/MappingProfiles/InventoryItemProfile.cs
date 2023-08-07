using AutoMapper;
using TataGamedomWebAPI.Application.Features.InventoryItem.Commands.CreateInventoryItem;
using TataGamedomWebAPI.Application.Features.InventoryItem.Queries.GetInventoryItemDetails;
using TataGamedomWebAPI.Application.Features.InventoryItem.Queries.GetInventoryItemList;
using TataGamedomWebAPI.Application.Features.InventoryItem.Queries.GetRemainingInventoryDetails;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.MappingProfiles;

public class InventoryItemProfile : Profile
{
    public InventoryItemProfile()
    {
        CreateMap<InventoryItem, InventoryItemDto>();
        CreateMap<InventoryItem, InventoryItemDetailsDto>();
        CreateMap<CreateInventoryItemCommand, InventoryItem>();
    }
}
