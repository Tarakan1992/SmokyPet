using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmokyPet.Domain.Entities;
using System.Collections.Generic;

namespace SmokyPet.Infrastructure.Mapping
{
    public class PetMap : EntityMap<Pet>
    {
        public override void Configure(EntityTypeBuilder<Pet> builder)
        {
            base.Configure(builder);

            builder.HasMany(e => e.Owners).WithMany(e => e.Pets)
                .UsingEntity<Dictionary<string, object>>(
                    "pet_owner",
                    e => e.HasOne<Owner>().WithMany().HasForeignKey("OwnerId"),
                    e => e.HasOne<Pet>().WithMany().HasForeignKey("PetId")
                );
        }
    }
}
