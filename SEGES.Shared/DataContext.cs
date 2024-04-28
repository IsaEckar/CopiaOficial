using Microsoft.EntityFrameworkCore;
using SEGES.Shared.Entities;

namespace SEGES.Shared
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>()
                .HasKey(c => c.CityId);
            modelBuilder.Entity<City>()
                .Property(c => c.CityId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<City>()
                .HasIndex(x => new { x.StateId, x.Name })
                .IsUnique();

            modelBuilder.Entity<Country>()
                .HasKey(c => c.CountryId);
            modelBuilder.Entity<Country>()
                .Property(c => c.CountryId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Country>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<Module>()
                .HasKey(c => c.ModuleId);
            modelBuilder.Entity<Module>()
                .Property(c => c.ModuleId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Module>()
                .HasIndex(x => x.Name)
                .IsUnique();
            modelBuilder.Entity<Module>()
                .HasMany(m => m.Permissions)
                .WithOne(p => p.Module)
                .HasForeignKey(p => p.Module_ID);
            modelBuilder.Entity<Module>()
                .Property(k => k.CreationDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<DocTraceability>()
               .HasKey(uc => uc.DocTraceabilityId);
            modelBuilder.Entity<DocTraceability>()
                .Property(uc => uc.CreationDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<DocTraceability>()
                .HasOne(dc => dc.Type)
                .WithMany()
                .HasForeignKey(dc => dc.Type_Id);
            modelBuilder.Entity<DocTraceability>()
                .HasOne(dc => dc.Source)
                .WithMany()
                .HasForeignKey(dc => dc.Source_Id);

            modelBuilder.Entity<Module>()
             .HasKey(c => c.ModuleId);
            modelBuilder.Entity<Module>()
                .Property(c => c.ModuleId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Module>()
                .HasIndex(x => x.Name)
                .IsUnique();
            modelBuilder.Entity<Module>()
                .HasMany(m => m.Permissions)
                .WithOne(p => p.Module)
                .HasForeignKey(p => p.Module_ID);
            modelBuilder.Entity<Module>()
                .Property(k => k.CreationDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Issue>()
                .HasOne(i => i.Project)
                .WithMany(p => p.Issues)
                .HasForeignKey(i => i.Project_ID);
            modelBuilder.Entity<Issue>()
                .Property(i => i.CreationDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Goal>()
                .HasKey(g => g.GoalId);
            modelBuilder.Entity<Goal>()
                .Property(i => i.GoalId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Goal>()
                .Property(g => g.CreationDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");


            modelBuilder.Entity<Rel_IssueGoal>()
               .HasKey(rig => new { rig.Issue_ID, rig.Goal_ID });
            modelBuilder.Entity<Rel_IssueGoal>()
                .HasOne(rig => rig.Issue)
                .WithMany(i => i.IssueGoals)
                .HasForeignKey(rig => rig.Issue_ID);
            modelBuilder.Entity<Rel_IssueGoal>()
                .HasOne(rig => rig.Goal)
                .WithMany(g => g.IssueGoals)
                .HasForeignKey(rig => rig.Goal_ID);
            modelBuilder.Entity<Rel_IssueGoal>()
                .Property(rig => rig.CreationDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<HUApprovalStatus>()
                .HasKey(us => us.HUApprovalStatusId);

            modelBuilder.Entity<HUPriority>()
                .HasKey(us => us.PriorityId);

            modelBuilder.Entity<DocTraceabilityType>()
                .HasKey(us => us.DocTraceabilityTypeId);
            DisableCascadingDelete(modelBuilder);


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
        public DbSet<Country> Countries { get; set; }
        public DbSet<DocTraceability> DocTraceabilities { get; set; }
    }
}