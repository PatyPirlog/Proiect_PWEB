using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proiect_PWEB.Core;

namespace Proiect_PWEB.Infrastructure.Data.EntityConfigurations
{
    public class CategoryConfiguration : EntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(20);

            base.Configure(builder);
        }
    }
}
