using Volo.Abp.Domain.Entities.Auditing;

namespace ABP.Demo1.Entities
{
    public class Product : FullAuditedEntity<int>
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
