using AutoMapper;
using DogsFieldShop.API.Dtos;
using DogsFieldShop.Core.Entities;

namespace DogsFieldShop.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>().
                ForMember(x => x.ProductBrand, y => y.MapFrom(s => s.ProductBrand.Name)).
                ForMember(x => x.ProductType, y => y.MapFrom(s => s.ProductType.Name));
        }
    }
}
