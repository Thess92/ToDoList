using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class MyDbContext : DbContext
    {
        string connectionString = "Server=(localdb)\\mssqllocaldb;Database=ToDoList;Trusted_Connection=True;MultipleActiveResultSets=true";

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // We tell the app to use the connectionstring.
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            ModelBuilder.Entity<Project>().HasData(new Project { Id = 1, Name = "First Project" });
            ModelBuilder.Entity<Project>().HasData(new Project { Id = 2, Name = "Second Project" });
            ModelBuilder.Entity<Project>().HasData(new Project { Id = 3, Name = "Third Project" });

            ModelBuilder.Entity<Task>().HasData(new Task { Id = 1, Title = "First Task", DueDate = new DateTime(2022, 12, 28), IsDone = false, ProjectId = 3 });
            ModelBuilder.Entity<Task>().HasData(new Task { Id = 2, Title = "Second Task", DueDate = new DateTime(2022, 12, 22), IsDone = true, ProjectId = 1 });
            ModelBuilder.Entity<Task>().HasData(new Task { Id = 3, Title = "Third Task", DueDate = new DateTime(2022, 12, 24), IsDone = true, ProjectId = 3 });
            ModelBuilder.Entity<Task>().HasData(new Task { Id = 4, Title = "Forth Task", DueDate = new DateTime(2022, 12, 26), IsDone = false, ProjectId = 2 });
            ModelBuilder.Entity<Task>().HasData(new Task { Id = 5, Title = "Fifth Task", DueDate = new DateTime(2022, 12, 23), IsDone = false, ProjectId = 1 });
            ModelBuilder.Entity<Task>().HasData(new Task { Id = 6, Title = "Sixth Task", DueDate = new DateTime(2022, 12, 25), IsDone = true, ProjectId = 2 });
        }
    }
}