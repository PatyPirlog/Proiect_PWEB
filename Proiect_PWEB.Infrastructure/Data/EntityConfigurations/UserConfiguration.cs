
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proiect_PWEB.Core;
using Proiect_PWEB.Infrastructure.Data.EntityConfigurations;

namespace Proiect_PWEB.Infrastructure
{
    public class UserConfiguration : EntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.Property(x => x.Name).IsRequired();
            //builder.Property(x => x.Surname).IsRequired();
            //builder.Property(x => x.Email).IsRequired();
            //builder.Property(x => x.Phone).IsRequired();

            //builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
            //builder.Property(e => e.IsDeleted).HasDefaultValue(false);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(e => e.Surname)
                .IsRequired()
                .HasMaxLength(100);

            base.Configure(builder);
            //Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;
        }
    }
}
