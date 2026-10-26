using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ABP.Demo1.Products
{
    public interface IProductsAppService : IApplicationService
    {
        Task<ProductDto> CreateProductAsync(AddOrEditProductDto input);
        Task<ProductDto> UpdateProductAsync(AddOrEditProductDto input);
        Task<ProductDto> GetProductAsync(int id);
        Task<bool> DeleteProductAsync(int id);
        Task<PagedResultDto<ProductDto>> GetAllProductsAsync(GetProductListDto input);
    }
}
