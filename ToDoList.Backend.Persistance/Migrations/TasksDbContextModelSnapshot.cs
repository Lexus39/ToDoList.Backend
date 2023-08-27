﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ToDoList.Backend.Persistance;

#nullable disable

namespace ToDoList.Backend.Persistance.Migrations
{
    [DbContext(typeof(TasksDbContext))]
    partial class TasksDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "task_state", new[] { "active", "finished" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ToDoList.Backend.Core.Models.TaskModel.TaskModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("task_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("date")
                        .HasColumnName("created_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime?>("FinishDate")
                        .HasColumnType("date")
                        .HasColumnName("finish_date");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("task_status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.HasKey("Id");

                    b.HasAlternateKey("Id", "UserName");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("UserName");

                    b.ToTable("tasks", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
