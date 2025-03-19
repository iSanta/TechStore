using AutoMapper;
using TechStore.Core.Entities;
using TechStore.Domain.Models.DTO;

namespace TechStore.Domain.Models.Profiles
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryBaseDto>();
            CreateMap<Brand, BrandBaseDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Brand, BrandDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Product, ProductBaseDto>();
        }
    }
}
