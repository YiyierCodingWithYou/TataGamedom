using AutoMapper;
using TataGamedomWebAPI.Application.Features.Product.Queries.GetProductTopFiveSalesList;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.MappingProfiles;

public class GameProfile : Profile
{
    public GameProfile()
    {
        CreateMap<Game, GameDto>().ReverseMap();
    }
}

