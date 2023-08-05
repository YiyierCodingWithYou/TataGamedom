using AutoMapper;
using TataGamedomWebAPI.Application.Features.Product.Queries.GetProductTopFiveSalesList;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.MappingProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductTopFiveSalesDto>().ReverseMap();
    }
}

