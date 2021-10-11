using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmokyPet.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmokyPet.Infrastructure
{
    public class SmokyPetDbContext : DbContext
    {
        public SmokyPetDbContext(DbContextOptions<SmokyPetDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var utcNow = DateTime.UtcNow;

            var addedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Added && typeof(IDateCreatedTrackingEntity).IsAssignableFrom(e.Metadata.ClrType)).ToList();

            addedEntities.ForEach(e =>
            {
                e.Property(nameof(IDateTrackingEntity.DateCreated)).CurrentValue = utcNow;
            });

            var editedEntities = ChangeTracker.Entries().Where(e => (e.State == EntityState.Modified || e.State == EntityState.Added) && typeof(IDateUpdatedTrackingEntity).IsAssignableFrom(e.Metadata.ClrType)).ToList();

            editedEntities.ForEach(e =>
            {
                e.Property(nameof(IDateTrackingEntity.DateUpdated)).CurrentValue = utcNow;
            });

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
