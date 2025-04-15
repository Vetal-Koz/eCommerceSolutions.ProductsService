using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductResponse>()
            .ForMember(dest => dest.ProductId,
                opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.ProductName,
                opt => opt.MapFrom(src => src.ProductName))
            .ForMember(dest => dest.UnitPrice,
                opt => opt.MapFrom(src => src.UnitPrice))
            .ForMember(dest => dest.QuantityInStock,
                opt => opt.MapFrom(src => src.QuantityInStock))
            .ForMember(dest => dest.QuantityInStock,
                opt => opt.MapFrom((src) => src.Category));

    }
}