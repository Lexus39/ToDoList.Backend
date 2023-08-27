using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Backend.Persistance.Migrations
{
    public partial class ChangeUserIdToUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_tasks_title_user_id",
                table: "tasks");

            migrationBuilder.DropIndex(
                name: "IX_tasks_user_id",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "tasks");

            migrationBuilder.AddColumn<string>(
                name: "user_name",
                table: "tasks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_tasks_title_user_name",
                table: "tasks",
                columns: new[] { "title", "user_name" });

            migrationBuilder.CreateIndex(
                name: "IX_tasks_user_name",
                table: "tasks",
                column: "user_name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_tasks_title_user_name",
                table: "tasks");

            migrationBuilder.DropIndex(
                name: "IX_tasks_user_name",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "user_name",
                table: "tasks");

            migrationBuilder.AddColumn<long>(
                name: "user_id",
                table: "tasks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_tasks_title_user_id",
                table: "tasks",
                columns: new[] { "title", "user_id" });

            migrationBuilder.CreateIndex(
                name: "IX_tasks_user_id",
                table: "tasks",
                column: "user_id");
        }
    }
}
