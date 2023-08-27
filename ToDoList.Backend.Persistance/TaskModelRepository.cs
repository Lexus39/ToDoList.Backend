using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Backend.Core;
using ToDoList.Backend.Core.Models.TaskModel;

namespace ToDoList.Backend.Persistance
{
    public class TaskModelRepository : ITaskModelRepository
    {
        private readonly TasksDbContext _dbContext;

        public TaskModelRepository(TasksDbContext dbContext) 
            => _dbContext = dbContext;

        public async Task<long> CreateTaskModel(TaskModel task)
        {
            var addedTask = await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();
            return addedTask.Entity.Id;
        }

        public async Task<long> DeleteTaskModel(TaskModel task)
        {
            var deletedTask = _dbContext.Tasks.Remove(task);
            await _dbContext.SaveChangesAsync();
            return deletedTask.Entity.Id;
        }

        public async Task<TaskModel> GetTaskModelById(long taskId)
        {
            var taskModel = await _dbContext.Tasks.AsNoTracking().SingleAsync(task => task.Id == taskId);
            return taskModel;
        }

        public async Task<List<TaskModel>> ListTaskModelByUser(string userName)
        {
            var taskList = await _dbContext.Tasks
                .AsNoTracking()
                .Where(task => task.UserName == userName)
                .ToListAsync();
            return taskList;
        }

        public async Task UpdateTaskModel(long taskId, TaskModel updatedTask)
        {
            var task = await _dbContext.Tasks.SingleAsync(task => task.Id == taskId);
            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.FinishDate = updatedTask.FinishDate;
            task.Status = updatedTask.Status;
            await _dbContext.SaveChangesAsync();
        }
    }
}
