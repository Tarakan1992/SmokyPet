using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

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
    }
}
