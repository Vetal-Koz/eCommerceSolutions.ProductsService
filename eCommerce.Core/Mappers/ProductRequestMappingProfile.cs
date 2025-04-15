using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers;

public class ProductRequestMappingProfile : Profile
{
    public ProductRequestMappingProfile()
    {
        CreateMap<ProductAddRequest, Product>()
            .ForMember(dest => dest.ProductName,
                opt => opt.MapFrom(src => src.ProductName))
            .ForMember(dest => dest.Category,
                opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.QuantityInStock,
                opt => opt.MapFrom(src => src.QuantityInStock))
            .ForMember(dest => dest.UnitPrice,
                opt => opt.MapFrom(src => src.UnitPrice));
        
        CreateMap<ProductUpdateRequest, Product>()
            .ForMember(dest => dest.ProductName,
                opt => opt.MapFrom(src => src.ProductName))
            .ForMember(dest => dest.Category,
                opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.QuantityInStock,
                opt => opt.MapFrom(src => src.QuantityInStock))
            .ForMember(dest => dest.UnitPrice,
                opt => opt.MapFrom(src => src.UnitPrice));
    }
    
}