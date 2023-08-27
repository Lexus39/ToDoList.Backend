namespace ToDoList.Backend.Core.Models.TaskModel
{
    public class TaskModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public TaskModelStatus Status { get; set; }
        public string UserName { get; set; } = null!;
    }
}