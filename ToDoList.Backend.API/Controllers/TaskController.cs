using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoList.Backend.Core;
using ToDoList.Backend.Core.Dto;
using ToDoList.Backend.Core.Models.TaskModel;

namespace ToDoList.Backend.API.Controllers
{
    [Authorize]
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;
        private readonly UserService _userService;

        public TaskController(TaskService service, UserService userService)
        {
            _taskService = service;
            _userService = userService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<long>> Create(CreateTaskDto dto)
        {
            dto.UserName = _userService.GetCurrentUserName();
            var userId = await _taskService.CreateTask(dto);
            return Ok(userId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> Get(long id)
        {
            var userName = _userService.GetCurrentUserName();
            var task = await _taskService.GetTask(id, userName);
            return Ok(task);
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetAll()
        {
            var userName = _userService.GetCurrentUserName();
            var tasks = await _taskService.ListTasks(userName);
            return Ok(tasks);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateTaskDto dto)
        {
            dto.UserName = _userService.GetCurrentUserName();
            await _taskService.UpdateTask(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var userName = _userService.GetCurrentUserName();
            await _taskService.DeleteTask(id, userName);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> FinishTask(long id)
        {
            var userName = _userService.GetCurrentUserName();
            await _taskService.FinishTask(id, userName);
            return Ok();
        }
    }
}
