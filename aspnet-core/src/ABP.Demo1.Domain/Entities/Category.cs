using Volo.Abp.Domain.Entities.Auditing;

namespace ABP.Demo1.Entities
{
    // Categories usually be a lookup, due to it contains a few records.
    // So, I can make it inherit from Entity<> enough, no need to inherit from FullAuditedEntity<>, no body will update them frequentrly.
    public class Category : FullAuditedEntity<int>
    {
        public Category(int id, string nameEn, string nameAr, string descriptionEn, string descriptionAr) : base(id)
        {
            //Id = id; __ I already set the Id in the base constructor, no need to set it again.
            NameEn = nameEn;
            NameAr = nameAr;
            DescriptionEn = descriptionEn;
            DescriptionAr = descriptionAr;
        }

        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }

    }
}
