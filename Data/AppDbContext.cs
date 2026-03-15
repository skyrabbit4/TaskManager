using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }

        public  DbSet<Organization> Organizations {get; set;}
        public DbSet<Team> Teams {get; set;}
        public DbSet<User> Users {get; set;}
        public DbSet<Project> Projects {get; set;}

        public DbSet<TaskItem> TaskItems{get ; set;}
        public DbSet<SubTask> SubTasks {get; set;}
        public DbSet<TaskHistory> TaskHistories {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("Organizations");
                entity.Property(e=>e.Id).HasColumnName("id");
                entity.Property(e=>e.CreatedAt).HasColumnName("created_at");
                entity.Property(e=>e.Name).HasColumnName("name");
                entity.Property(e=>e.Description).HasColumnName("description");
                entity.Property(e=>e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("teams");
                entity.Property(e=>e.Id).HasColumnName("id");
                entity.Property(e=>e.Name).HasColumnName("name");
                entity.Property(e=>e.CreatedAt).HasColumnName("created_at");
                entity.Property(e=>e.Description).HasColumnName("description");
                entity.Property(e=>e.OrganizationId).HasColumnName("organization_id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.Property(e=>e.Id).HasColumnName("id");
                entity.Property(e=>e.Name).HasColumnName("name");
                entity.Property(e=>e.Email).HasColumnName("email");
                entity.Property(e=>e.GoogleId).HasColumnName("google_id");
                entity.Property(e=>e.Role).HasColumnName("role");
                entity.Property(e=>e.Position).HasColumnName("position");
                entity.Property(e=>e.ProfilePicture).HasColumnName("profile_picture");
                entity.Property(e=>e.UpdatedAt).HasColumnName("updated_at");
                entity.Property(e=>e.CreatedAt).HasColumnName("created_at");
                entity.Property(e=>e.TeamId).HasColumnName("team_id");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Projects");
                entity.Property(e=>e.Id).HasColumnName("id");
                entity.Property(e=>e.Name).HasColumnName("name");
                entity.Property(e=>e.Description).HasColumnName("description");
                entity.Property(e=>e.CreatedAt).HasColumnName("created_at");
                entity.Property(e=>e.UpdatedAt).HasColumnName("updated_at");
                entity.Property(e=>e.TeamId).HasColumnName("team_id");
                entity.Property(e=>e.StartDate).HasColumnName("start_date");
                entity.Property(e=>e.EndDate).HasColumnName("end_date");
                entity.Property(e=>e.Status).HasColumnName("status");
                entity.Property(e=>e.CreatedBy).HasColumnName("created_by");
            });

             modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.ToTable("Tasks");
                entity.Property(e=>e.Id).HasColumnName("id");
                entity.Property(e=>e.Title).HasColumnName("title");
                entity.Property(e=>e.Description).HasColumnName("description");
                entity.Property(e=>e.Status).HasColumnName("status");
                entity.Property(e=>e.CreatedAt).HasColumnName("created_at");
                entity.Property(e=>e.UpdatedAt).HasColumnName("updated_at");
                entity.Property(e=>e.ProjectId).HasColumnName("project_id");
                entity.Property(e=>e.StartDate).HasColumnName("start_date");
                entity.Property(e=>e.EndDate).HasColumnName("end_date");
                entity.Property(e=>e.Priority).HasColumnName("priority");
                entity.Property(e=>e.EffortHours).HasColumnName("effort_hours");
                entity.Property(e=>e.CreatedBy).HasColumnName("created_by");
                entity.Property(e=>e.AssignedTo).HasColumnName("assigned_to");

            });

             modelBuilder.Entity<SubTask>(entity =>
            {
                entity.ToTable("Subtasks");
                entity.Property(e=>e.Id).HasColumnName("id");
                entity.Property(e=>e.Title).HasColumnName("title");
                entity.Property(e=>e.Status).HasColumnName("status");
                entity.Property(e=>e.CreatedAt).HasColumnName("created_at");
                entity.Property(e=>e.OrderIndex).HasColumnName("order_index");
                entity.Property(e=>e.TaskId).HasColumnName("task_id");
            });

             modelBuilder.Entity<TaskHistory>(entity =>
            {
                entity.ToTable("Task_History");
                entity.Property(e=>e.Id).HasColumnName("id");
                entity.Property(e=>e.NewValue).HasColumnName("new_value");
                entity.Property(e=>e.OldValue).HasColumnName("old_value");
                entity.Property(e=>e.FieldChanged).HasColumnName("field_changed");
                entity.Property(e=>e.ChangedAt).HasColumnName("changed_at");
                entity.Property(e=>e.ChangedBy).HasColumnName("changed_by");
                entity.Property(e=>e.TaskId).HasColumnName("task_id");


            });

        }

    }
}