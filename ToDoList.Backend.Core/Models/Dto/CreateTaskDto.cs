namespace ToDoList.Backend.Core.Dto
{
    public class CreateTaskDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public string? UserName { get; set; }
    }
}