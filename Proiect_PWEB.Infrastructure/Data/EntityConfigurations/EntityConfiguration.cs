using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proiect_PWEB.Core;

namespace Proiect_PWEB.Infrastructure.Data.EntityConfigurations
{
    public abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            //builder
            //    .Property(x => x.IsDeleted)
            //    .ValueGeneratedOnAdd()
            //    .HasDefaultValueSql("0");

            //builder
            //    .Property(x => x.CreatedAt)
            //    .ValueGeneratedOnAdd();

            //builder
            //    .Property(x => x.UpdatedAt)
            //    .ValueGeneratedOnAddOrUpdate();
        }
    }
}
