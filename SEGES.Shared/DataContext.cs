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

            modelBuilder.Entity<Country>()
                .HasKey(c => c.CountryId);
            modelBuilder.Entity<Country>()
                .Property(c => c.CountryId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Country>()
                .HasIndex(x => x.Name)
                .IsUnique();

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

            modelBuilder.Entity<City>()
                .HasKey(c => c.CityId);
            modelBuilder.Entity<City>()
                .Property(c => c.CityId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<City>()
                .HasIndex(x => new { x.StateId, x.Name })
                .IsUnique();
            modelBuilder.Entity<City>()
                .HasOne(c => c.State)
                .WithMany(p => p.Cities)
                .HasForeignKey(c => c.StateId);

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

            modelBuilder.Entity<Role>()
                .HasKey(c => c.RoleId);
            modelBuilder.Entity<Role>()
                .Property(c => c.RoleId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Role>()
                .HasIndex(x => x.RoleName);

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

            modelBuilder.Entity<Permission>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Permission>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Permission>()
                .HasIndex(p => p.Name)
                .IsUnique();
            modelBuilder.Entity<Permission>()
                .Property(p => p.CreationDate)
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

            modelBuilder.Entity<Project>()
                .HasKey(c => c.ProjectId);
            modelBuilder.Entity<Project>()
                .Property(c => c.ProjectId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Project>()
                .HasIndex(x => x.ProjectName)
                .IsUnique();
            modelBuilder.Entity<Project>()
                .Property(p => p.CreationDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Project>()
                .HasOne(p => p.ProjectManager)
                .WithMany()
                .HasForeignKey(p => p.ProjectManager_ID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Project>()
                .HasOne(p => p.RequirementsEngineer)
                .WithMany()
                .HasForeignKey(p => p.RequirementsEngineer_ID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Project>()
                .HasOne(p => p.StakeHolder)
                .WithMany()
                .HasForeignKey(p => p.StakeHolder_ID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Project>()
                .HasOne(p => p.ProjectStatus)
                .WithMany()
                .HasForeignKey(p => p.ProjectStatus_ID);

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

            modelBuilder.Entity<KPI>()
                .HasKey(k => k.KPI_ID);
            modelBuilder.Entity<KPI>()
                .Property(k => k.CreationDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<KPI>()
                .HasOne(k => k.Goal)
                .WithMany(g => g.KPIs)
                .HasForeignKey(k => k.Goal_Id);

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

            modelBuilder.Entity<SourceDocTraceability>()
                .HasKey(us => us.SorceId);

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

            modelBuilder.Entity<HUApprovalStatus>()
                .HasKey(us => us.HUApprovalStatusId);

            modelBuilder.Entity<HUPriority>()
                .HasKey(us => us.PriorityId);

            modelBuilder.Entity<HUPublicationStatus>()
                .HasKey(us => us.HUPublicationStatusId);

            modelBuilder.Entity<HUStatus>()
                .HasKey(us => us.HUStatusId);

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
