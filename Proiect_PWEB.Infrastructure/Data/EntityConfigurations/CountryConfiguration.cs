using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proiect_PWEB.Core;

namespace Proiect_PWEB.Infrastructure.Data.EntityConfigurations
{
    public class CountryConfiguration : EntityConfiguration<Country>
    {
        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            //builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            base.Configure(builder);
        }
    }
}
