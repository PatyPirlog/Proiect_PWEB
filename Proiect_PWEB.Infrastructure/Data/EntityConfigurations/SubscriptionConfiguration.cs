using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proiect_PWEB.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Infrastructure.Data.EntityConfigurations
{
    public class SubscriptionConfiguration : EntityConfiguration<Subscription>
    {
        public override void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasOne(d => d.Country)
                    .WithMany(p => p.Subscription)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.User)
                        .WithMany(p => p.Subscription)
                        .HasForeignKey(d => d.UserId)
                        .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
