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
    public class RequestConfiguration : EntityConfiguration<Request>
    {
        public override void Configure(EntityTypeBuilder<Request> builder)
        {
            //builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Name)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(e => e.Surname)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Description).IsRequired();

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasOne(d => d.Category)
                .WithMany(p => p.Request)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Country)
                .WithMany(p => p.Request)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.User)
                .WithMany(p => p.Request)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.Configure(builder);
        }
    }
}
