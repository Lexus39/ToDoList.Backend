using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Backend.Core;
using ToDoList.Backend.Core.Dto;
using ToDoList.Backend.Core.Models.TaskModel;

namespace ToDoList.Backend.Core
{
    public class TaskService
    {
        private readonly ITaskModelRepository _repository;

        public TaskService(ITaskModelRepository repository)
        {
            _repository = repository;
        }

        public async Task<long> CreateTask(CreateTaskDto dto)
        {
            var task = new TaskModel()
            {
                Id = 0,
                Title = dto.Title,
                Description = dto.Description,
                CreationDate = dto.CreationDate,
                FinishDate = null,
                Status = TaskModelStatus.Active,
                UserName = dto.UserName ?? ""
            };
            return await _repository.CreateTaskModel(task);
        }

        public async Task UpdateTask(UpdateTaskDto dto)
        {
            var task = await _repository.GetTaskModelById(dto.Id);
            if (task.UserName != dto.UserName)
                throw new ArgumentException();
            task.Title = dto.Title;
            task.Description = dto.Description;
            await _repository.UpdateTaskModel(dto.Id, task);
        }

        public async Task<TaskModel> GetTask(long taskId, string userName)
        {
            var task = await _repository.GetTaskModelById(taskId);
            if (task.UserName != userName)
                throw new ArgumentException();
            return task;
        }

        public async Task<List<TaskModel>> ListTasks(string userName)
        {
            return await _repository.ListTaskModelByUser(userName);
        }

        public async Task<long> DeleteTask(long taskId, string userName)
        {
            var task = await _repository.GetTaskModelById(taskId);
            if (task.UserName != userName)
                throw new ArgumentException();
            return await _repository.DeleteTaskModel(task);
        }

        public async Task FinishTask(long taskId, string userName)
        {
            var task = await _repository.GetTaskModelById(taskId);
            if (task.UserName != userName)
                throw new ArgumentException();
            task.FinishDate = DateTime.Now;
            task.Status = TaskModelStatus.Finished;
            await _repository.UpdateTaskModel(taskId, task);
        }
    }
}
