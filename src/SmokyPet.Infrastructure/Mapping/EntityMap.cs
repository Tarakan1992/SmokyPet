using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmokyPet.Domain.Entities;
using System.Linq;

namespace SmokyPet.Infrastructure.Mapping
{
    public class EntityMap<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IEntity
    {
        protected virtual string TableName => string.Concat(typeof(TEntity).Name.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString()));

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(e => e.Id);
        }
    }
}
