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



            modelBuilder.Entity<DocTraceability>()
                .HasKey(uc => uc.DocTraceabilityId);
            modelBuilder.Entity<DocTraceability>()
                .Property(uc => uc.CreationDate)
                .ValueGeneratedOnAdd().
                HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<DocTraceability>()
                .HasOne(dc => dc.Type)
                .WithMany()
                .HasForeignKey(dc => dc.Type_Id);
            modelBuilder.Entity<DocTraceability>()
                .HasOne(dc => dc.Source)
                .WithMany()
                .HasForeignKey(dc => dc.Source_Id);


            modelBuilder.Entity<Goal>()
                .HasKey(g => g.GoalId);
            modelBuilder.Entity<Goal>()
                .Property(i => i.GoalId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Goal>()
                .Property(g => g.CreationDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");


            modelBuilder.Entity<Rel_RolPermission>()
                .HasKey(rp => new { rp.Role_ID, rp.Permission_ID });
            modelBuilder.Entity<Rel_RolPermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RelPermissions)
                .HasForeignKey(rp => rp.Role_ID);
            modelBuilder.Entity<Rel_RolPermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolPermissions)
                .HasForeignKey(rp => rp.Permission_ID);


            modelBuilder.Entity<Requirement>()
                .HasKey(rq => rq.RequirementID);
            modelBuilder.Entity<Requirement>()
                .Property(rq => rq.CreationDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Requirement>()
                .HasOne(rq => rq.Goal)
                .WithMany(g => g.Requirements)
                .HasForeignKey(rq => rq.Goal_ID);


            modelBuilder.Entity<Role>()
                .HasKey(c => c.RoleId);
            modelBuilder.Entity<Role>()
                .Property(c => c.RoleId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Role>()
                .HasIndex(x => x.RoleName);

            modelBuilder.Entity<SecundaryKPI>()
                .HasKey(sk => sk.SecundaryKPI_Id);
            modelBuilder.Entity<SecundaryKPI>()
                .Property(sk => sk.CreationDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<SecundaryKPI>()
                .HasOne(sk => sk.KPI)
                .WithMany(g => g.SecundaryKPIs)
                .HasForeignKey(sk => sk.KPI_Id);


            modelBuilder.Entity<SourceDocTraceability>()
                .HasKey(us => us.SorceId);


            modelBuilder.Entity<State>()
                .HasKey(c => c.StateId);
            modelBuilder.Entity<State>()
                .Property(c => c.StateId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<State>()
                .HasIndex(x => new { x.CountryId, x.Name })
                .IsUnique();
            modelBuilder.Entity<State>()
                .HasOne(c => c.Country)
                .WithMany(p => p.States)
                .HasForeignKey(d => d.CountryId);


            modelBuilder.Entity<UseCase>()
                .HasKey(uc => uc.UseCaseID);
            modelBuilder.Entity<UseCase>()
                .Property(uc => uc.CreationDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<UseCase>()
                .HasOne(uc => uc.Requirement)
                .WithMany(g => g.UseCases)
                .HasForeignKey(uc => uc.Requirement_Id);


            modelBuilder.Entity<User>()
                .HasKey(c => c.UserId);
            modelBuilder.Entity<User>()
                .Property(c => c.UserId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>()
                .HasIndex(x => x.Name)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasOne(c => c.City)
                .WithMany()
                .HasForeignKey(c => c.City_Id);
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.Role_ID);

            modelBuilder.Entity<UserStory>()
                .HasKey(us => us.UserStoryId);
            modelBuilder.Entity<UserStory>()
                .Property(us => us.CreationDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<UserStory>()
                .HasOne(us => us.Requirement)
                .WithMany(g => g.UserStories)
                .HasForeignKey(us => us.Requirement_Id);
            modelBuilder.Entity<UserStory>()
                .HasOne(us => us.HUApprovalStatus)
                .WithMany()
                .HasForeignKey(us => us.HUApprovalStatus_Id);
            modelBuilder.Entity<UserStory>()
                .HasOne(us => us.HUPriority)
                .WithMany()
                .HasForeignKey(us => us.HUPriority_Id);
            modelBuilder.Entity<UserStory>()
                .HasOne(us => us.HUStatus)
                .WithMany()
                .HasForeignKey(us => us.HUStatus_Id);
            modelBuilder.Entity<UserStory>()
                .HasOne(us => us.HUPublicationStatus)
                .WithMany()
                .HasForeignKey(us => us.HUPublicationStatus_Id);

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

        public DbSet<Rel_RolPermission> Rel_RolPermissions { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<SecundaryKPI> SecundaryKPIs { get; set; }
        public DbSet<SourceDocTraceability> SourceDocTraceabilitys { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<UseCase> UseCases { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserStory> UserStories { get; set; }


    }
}