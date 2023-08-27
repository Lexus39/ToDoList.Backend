using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Backend.Core.Models.TaskModel;

namespace ToDoList.Backend.Persistance.Configurations
{
    public class TaskModelConfiguration : IEntityTypeConfiguration<TaskModel>
    {
        public void Configure(EntityTypeBuilder<TaskModel> builder)
        {
            builder.ToTable("tasks");

            builder.Property(task => task.Id)
                .HasColumnName("task_id")
                .IsRequired();

            builder.Property(task => task.Title)
                .HasColumnName("title")
                .IsRequired();

            builder.Property(task => task.Description)
                .HasColumnName("description")
                .IsRequired();

            builder.Property(task => task.CreationDate)
                .HasColumnName("created_date")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(task => task.FinishDate)
                .HasColumnName("finish_date")
                .HasColumnType("date");

            builder.Property(task => task.Status)
                .HasColumnName("task_status")
                .IsRequired();

            builder.Property(task => task.UserName)
                .HasColumnName("user_name")
                .IsRequired();

            builder.HasAlternateKey(task => new { task.Id, task.UserName });

            builder.HasIndex(task => task.Id).IsUnique();

            builder.HasIndex(task => task.UserName);

            builder.HasKey(task => task.Id);
        }
    }
}
