using ABP.Demo1.Entities;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace ABP.Demo1.Seeders
{
    public class CategoriesDataSeeder : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Category, int> _repository;

        public CategoriesDataSeeder(IRepository<Category, int> repository)
        {
            _repository = repository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _repository.GetCountAsync() > 0)
            {
                return;
            }

            var categories = new[]
            {
                new Category(
                    id: 1,
                    nameEn: "Electronics",
                    nameAr: "الإلكترونيات",
                    descriptionEn: "Devices and gadgets",
                    descriptionAr: "الأجهزة والأدوات"),

                new Category(
                    id: 2,
                    nameEn: "Books",
                    nameAr: "الكتب",
                    descriptionEn: "Printed and digital books",
                    descriptionAr: "الكتب المطبوعة والرقمية"),

                new Category(
                    id: 3,
                    nameEn: "Clothing",
                    nameAr: "الملابس",
                    descriptionEn: "Apparel and accessories",
                    descriptionAr: "الملابس والإكسسوارات"),

                new Category(
                    id: 4,
                    nameEn: "Home & Kitchen",
                    nameAr: "المنزل والمطبخ",
                    descriptionEn: "Household items and kitchenware",
                    descriptionAr: "الأدوات المنزلية وأدوات المطبخ"),

                new Category(
                    id: 5,
                    nameEn: "Sports & Outdoors",
                    nameAr: "الرياضة والهواء الطلق",
                    descriptionEn: "Sporting goods and outdoor equipment",
                    descriptionAr: "السلع الرياضية ومعدات الهواء الطلق"),

                new Category(
                    id: 6,
                    nameEn: "Health & Beauty",
                    nameAr: "الصحة والجمال",
                    descriptionEn: "Personal care and beauty products",
                    descriptionAr: "منتجات العناية الشخصية والجمال"),

                new Category(
                    id: 7,
                    nameEn: "Toys & Games",
                    nameAr: "الألعاب",
                    descriptionEn: "Toys and games for all ages",
                    descriptionAr: "الألعاب لجميع الأعمار"),
            };

            await _repository.InsertManyAsync(categories, autoSave: true);
        }
    }
}