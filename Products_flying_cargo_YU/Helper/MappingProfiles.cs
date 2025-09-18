using AutoMapper;
using Products_flying_cargo_YU.Dto;
using Products_flying_cargo_YU.Models;

namespace Products_flying_cargo_YU.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Products, ProductsDto>()
                .ForMember(dest => dest.CategoryID,
                           opt => opt.MapFrom(src => src.ProductCategories
                                                       .Select(pc => pc.Category.CategoryID)
                                                       .FirstOrDefault()))
                .ForMember(dest => dest.CategoryName,
                           opt => opt.MapFrom(src => src.ProductCategories
                                                       .Select(pc => pc.Category.CategoryName)
                                                       .FirstOrDefault()));

            CreateMap<ProductsDto, Products>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
