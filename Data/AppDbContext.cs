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

    }
}