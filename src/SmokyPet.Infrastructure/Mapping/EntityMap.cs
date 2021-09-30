using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmokyPet.Domain.Entities;

namespace SmokyPet.Infrastructure.Mapping
{
    public class EntityMap<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}
