using ABP.Demo1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ABP.Demo1.Configurations
{
    internal class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // auto configure for the base class props (like Id, CreationTime, etc.), this default behavior done by abp framework, but you can remove it if you don't want to use it.
            builder.ConfigureByConvention();

            // make id abled to insert by user for seeding purpose [Category Entity Is Lookup, So it is often a seed].
            builder.Property(x => x.Id).ValueGeneratedNever();

            // then, you can configure your own business props here.

            builder.Property(x => x.NameEn).HasMaxLength(Demo1Consts.GeneralTextMaxLength).IsRequired();
            builder.Property(x => x.NameAr).HasMaxLength(Demo1Consts.GeneralTextMaxLength).IsRequired();
            builder.Property(x => x.DescriptionEn).HasMaxLength(Demo1Consts.DescriptionTextMaxLength).IsRequired();
            builder.Property(x => x.DescriptionAr).HasMaxLength(Demo1Consts.DescriptionTextMaxLength).IsRequired();

            builder.ToTable("Categories", "lookups"); // name of category and its schema

        }
    }
}
