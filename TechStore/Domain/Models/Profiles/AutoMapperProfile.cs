using AutoMapper;
using TechStore.Core.Entities;
using TechStore.Domain.Models.DTO;

namespace TechStore.Domain.Models.Profiles
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryDtoBase>();
            CreateMap<Brand, BrandDtoBase>();
            CreateMap<Product, ProductDto>();
        }
    }
}
