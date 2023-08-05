using AutoMapper;
using TataGamedomWebAPI.Application.Features.Product.Queries.GetProductTopFiveSalesList;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.MappingProfiles;

public class GamePlatformsCode : Profile
{
    public GamePlatformsCode()
    {
        CreateMap<GamePlatformsCode, GamePlatformsCodeDto>().ReverseMap();
    }
}

