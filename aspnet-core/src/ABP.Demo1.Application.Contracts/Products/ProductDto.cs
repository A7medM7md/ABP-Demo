using Volo.Abp.Application.Dtos;

namespace ABP.Demo1.Products
{
    public class ProductDto : FullAuditedEntityDto<int>
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }

        public int CategoryId { get; set; }

        // automapper will translate these props well from navigation prop.
        public string CategoryNameEn { get; set; }
        public string CategoryNameAr { get; set; }
        public string CategoryDescriptionEn { get; set; }
        public string CategoryDescriptionAr { get; set; }
    }
}
