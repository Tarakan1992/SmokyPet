using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmokyPet.Domain.Entities;
using System.Collections.Generic;

namespace SmokyPet.Infrastructure.Mapping
{
    public class OwnerMap : EntityMap<Owner>
    {
        public override void Configure(EntityTypeBuilder<Owner> builder)
        {
            base.Configure(builder);

            builder.HasMany(e => e.Pets).WithMany(e => e.Owners)
                .UsingEntity<Dictionary<string, object>>(
                    "pet_owner",
                    e => e.HasOne<Pet>().WithMany().HasForeignKey("PetId"),
                    e => e.HasOne<Owner>().WithMany().HasForeignKey("OwnerId")
                );
        }
    }
}
