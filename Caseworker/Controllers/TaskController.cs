using Caseworker.Models;
using Caseworker.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Caseworker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> Index()
        {
            int userId = int.Parse(User.Identity.Name);
            IEnumerable<TaskItem> todoItems = await _taskRepository.GetAllTasksAsync();
            return Ok(todoItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> Show(int id)
        {
            TaskItem todoItem = await _taskRepository.GetTaskByIdAsync(id);
            if (todoItem is null) return NotFound();

            int userId = int.Parse(User.Identity.Name);
            if (todoItem.UserId != userId) return Forbid();

            return Ok(todoItem);
        }

        [HttpPost]
        public async Task<ActionResult<TaskItem>> Create(TaskItem todoItem)
        {
            int userId = int.Parse(User.Identity.Name);
            todoItem.UserId = userId;
            await _taskRepository.CreateTaskAsync(todoItem);
            return CreatedAtAction(nameof(Show), new { id = todoItem.Id }, todoItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, TaskItem model)
        {
            TaskItem todoItem = await _taskRepository.GetTaskByIdAsync(id);
            if (todoItem is null) return NotFound();

            int userId = int.Parse(User.Identity.Name);
            if (todoItem.UserId != userId) return Forbid();

            await _taskRepository.UpdateTaskAsync(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            TaskItem todoItem = await _taskRepository.GetTaskByIdAsync(id);
            if (todoItem is null) return NotFound();

            int userId = int.Parse(User.Identity.Name);
            if (todoItem.UserId != userId) return Forbid();

            await _taskRepository.DeleteTaskAsync(id);
            return NoContent();
        }
    }
}
