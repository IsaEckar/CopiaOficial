﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SEGES.Shared.Entities;

namespace SEGES.Backend
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<City>().HasIndex(x => new { x.StateId, x.Name }).IsUnique();
            modelBuilder.Entity<State>().HasIndex(x => new { x.CountryId, x.Name }).IsUnique();
            modelBuilder.Entity<HUPriority>().HasKey(us => us.PriorityId);
            modelBuilder.Entity<Goal>().HasKey(g => g.GoalId); 
            modelBuilder.Entity<Module>().HasKey(c => c.ModuleId);
            modelBuilder.Entity<Permission>().HasKey(p => p.Id);
            modelBuilder.Entity<Project>() .HasKey(c => c.ProjectId);
            modelBuilder.Entity<KPI>().HasKey(k => k.KPI_ID);
            modelBuilder.Entity<SecundaryKPI>().HasKey(sk => sk.SecundaryKPI_Id);
            modelBuilder.Entity<Rel_RolPermission>().HasKey(rp => new { rp.Role_ID, rp.Permission_ID });
            modelBuilder.Entity<Rel_IssueGoal>().HasKey(rig => new { rig.Issue_ID, rig.Goal_ID });
            modelBuilder.Entity<Issue>().HasOne(i => i.Project);
            modelBuilder.Entity<HUApprovalStatus>().HasKey(us => us.HUApprovalStatusId);
            modelBuilder.Entity<HUPublicationStatus>().HasKey(us => us.HUPublicationStatusId);
            modelBuilder.Entity<HUStatus>().HasKey(us => us.HUStatusId);
            modelBuilder.Entity<DocTraceabilityType>().HasKey(us => us.DocTraceabilityTypeId);
            modelBuilder.Entity<SourceDocTraceability>().HasKey(us => us.SorceId);
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