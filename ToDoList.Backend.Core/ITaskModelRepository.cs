using ToDoList.Backend.Core.Models.TaskModel;

namespace ToDoList.Backend.Core
{
    public interface ITaskModelRepository
    {
        public Task<TaskModel> GetTaskModelById(long taskId);

        public Task<long> CreateTaskModel(TaskModel task);

        public Task UpdateTaskModel(long taskId, TaskModel updatedTask);

        public Task<long> DeleteTaskModel(TaskModel task);

        public Task<List<TaskModel>> ListTaskModelByUser(string userName);
    }
}