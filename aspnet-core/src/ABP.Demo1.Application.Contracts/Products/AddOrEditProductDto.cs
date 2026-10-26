using Volo.Abp.Application.Dtos;

namespace ABP.Demo1.Products
{
    public class AddOrEditProductDto : EntityDto<int>
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public int CategoryId { get; set; }
    }
}
