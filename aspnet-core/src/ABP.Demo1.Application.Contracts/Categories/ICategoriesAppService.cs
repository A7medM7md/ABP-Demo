using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ABP.Demo1.Categories
{
    // PagedAndSortedResultRequestDto is a type provided by abp contains filters, default inputs of list, you can customize on this type
    public interface ICategoriesAppService : ICrudAppService<CategoryDto, int, PagedAndSortedResultRequestDto, AddOrEditCategoryDto>
    {
        // This is a full crud service جاهزة
    }

    //public interface ICategoriesAppService : IApplicationService
    //{
    // Customized App Service
    //}
}
