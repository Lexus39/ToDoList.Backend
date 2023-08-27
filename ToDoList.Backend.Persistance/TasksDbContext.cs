using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Backend.Core.Models.TaskModel;
using ToDoList.Backend.Persistance.Configurations;

namespace ToDoList.Backend.Persistance
{
    public class TasksDbContext : DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; } = null!;

        public TasksDbContext(DbContextOptions<TasksDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TaskModelConfiguration());

            builder.HasPostgresEnum<TaskModelStatus>(name:"task_state");
        }
    }
}
