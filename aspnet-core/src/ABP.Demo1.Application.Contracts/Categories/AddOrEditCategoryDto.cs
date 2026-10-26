using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace ABP.Demo1.Categories
{
    // There are 2 ways to put validation on dtos, one is data annotation, the other is fluent validation, you can choose one of them, or even both of them if you want.

    public class AddOrEditCategoryDto : EntityDto<int>
    {
        [Required]
        [MaxLength(300)]
        public string NameEn { get; set; }
        [Required]
        [MaxLength(300)]
        public string NameAr { get; set; }
        [Required]
        [MaxLength(900)]
        public string DescriptionEn { get; set; }
        [Required]
        [MaxLength(900)]
        public string DescriptionAr { get; set; }
    }
}
