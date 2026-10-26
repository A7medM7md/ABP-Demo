using ABP.Demo1.Categories;
using ABP.Demo1.Entities;
using AutoMapper;

namespace ABP.Demo1.Mappings
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<AddOrEditCategoryDto, Category>();
        }
    }
}
