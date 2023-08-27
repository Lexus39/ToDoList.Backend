using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Backend.Persistance.Migrations
{
    public partial class AddEnumAndUniqueConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:task_state", "active,finished");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_tasks_title_user_id",
                table: "tasks",
                columns: new[] { "title", "user_id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_tasks_title_user_id",
                table: "tasks");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:task_state", "active,finished");
        }
    }
}
