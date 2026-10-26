using Volo.Abp.Application.Dtos;

namespace ABP.Demo1.Categories
{
    public class CategoryDto : FullAuditedEntityDto<int>
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
    }
}
