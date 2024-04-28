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

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<KPI> KPIs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<UseCase> UseCases { get; set; }
        public DbSet<UserStory> UserStories { get; set; }
        public DbSet<DocTraceability> DocTraceabilities { get; set; }
        public DbSet<HUStatus> HUStatuses { get; set; }
        public DbSet<HUPublicationStatus> HUPublicationStatuses { get; set; }
        public DbSet<HUPriority> HUPriorities { get; set; }
        public DbSet<Rel_IssueGoal> Rel_IssueGoals { get; set; }
        public DbSet<Rel_RolPermission> Rel_RolPermissions { get; set; }
        public DbSet<DocTraceabilityType> DocTraceabilityTypes { get; set; }
        public DbSet<HUApprovalStatus> HUApprovalStatuses { get; set; }
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }
    }
}
