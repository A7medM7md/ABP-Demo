using Volo.Abp.Application.Dtos;

namespace ABP.Demo1.Products
{
    public class GetProductListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
