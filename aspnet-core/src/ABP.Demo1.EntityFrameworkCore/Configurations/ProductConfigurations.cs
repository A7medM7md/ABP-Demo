using ABP.Demo1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ABP.Demo1.Configurations
{
    internal class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ConfigureByConvention();

            builder.Property(x => x.NameEn).HasMaxLength(Demo1Consts.GeneralTextMaxLength).IsRequired();
            builder.Property(x => x.NameAr).HasMaxLength(Demo1Consts.GeneralTextMaxLength).IsRequired();
            builder.Property(x => x.DescriptionEn).HasMaxLength(Demo1Consts.DescriptionTextMaxLength).IsRequired();
            builder.Property(x => x.DescriptionAr).HasMaxLength(Demo1Consts.DescriptionTextMaxLength).IsRequired();

            // relationship between Product and Category [Mandatory One-To-Many]
            builder.HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId)
                .IsRequired();

            builder.ToTable("Products");
        }
    }
}