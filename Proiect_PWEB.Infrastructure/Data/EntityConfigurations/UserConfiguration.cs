
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
            builder.Property(e => e.IdentityId)
                .HasMaxLength(300);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            base.Configure(builder);
        }
    }
}
