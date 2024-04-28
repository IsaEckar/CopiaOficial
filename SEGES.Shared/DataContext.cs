using Microsoft.EntityFrameworkCore;
using SEGES.Shared.Entities;

namespace SEGES.Shared
{
    internal class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<City>()
                .HasKey(c => c.CityId);
            modelBuilder.Entity<City>()
                .Property(c => c.CityId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<City>()
                .HasIndex(x => new { x.StateId, x.Name })
                .IsUnique();



        }

        private void DisableCascadingDelete(ModelBuilder modelBuilder)
        {
            var relationships = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
            foreach (var relationship in relationships)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public DbSet<City> Cities { get; set; }
    }
}