using Caseworker.Models;

namespace Caseworker.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllTasksAsync();
        Task<TaskItem> GetTaskByIdAsync(int id);
        Task CreateTaskAsync(TaskItem task);
        Task UpdateTaskAsync(int id, TaskItem task);
        Task DeleteTaskAsync(int id);
        Task<bool> TaskExistsAsync(int id);
    }
}
