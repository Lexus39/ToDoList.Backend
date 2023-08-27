using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Backend.Persistance.Migrations
{
    public partial class ChangeUniqueConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_tasks_title_user_name",
                table: "tasks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "finish_date",
                table: "tasks",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "tasks",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_tasks_task_id_user_name",
                table: "tasks",
                columns: new[] { "task_id", "user_name" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_tasks_task_id_user_name",
                table: "tasks");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "finish_date",
                table: "tasks",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "created_date",
                table: "tasks",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_tasks_title_user_name",
                table: "tasks",
                columns: new[] { "title", "user_name" });
        }
    }
}
