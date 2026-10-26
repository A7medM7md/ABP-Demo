using ABP.Demo1.Entities;
using ABP.Demo1.Products;
using AutoMapper;

namespace ABP.Demo1.Mappings
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<AddOrEditProductDto, Product>();
        }
    }
}
