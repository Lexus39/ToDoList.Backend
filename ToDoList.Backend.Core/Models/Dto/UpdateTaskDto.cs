using ToDoList.Backend.Core.Models.TaskModel;

namespace ToDoList.Backend.Core.Dto
{
    public class UpdateTaskDto
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? UserName { get; set; }
    }
}