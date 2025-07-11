using Caseworker.Models;
using Dapper;
using System.Data;

namespace Caseworker.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IDbConnection _connection;

        public TaskRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            string query = @"SELECT id, title, description, status, dueDate, createdOn FROM Tasks;";
            return await _connection.QueryAsync<TaskItem>(query);
        }

        public async Task<TaskItem> GetTaskByIdAsync(int id)
        {
            string query = @"SELECT id, title, description, status, dueDate, createdOn FROM Tasks WHERE id = @Id;";
            return await _connection.QuerySingleOrDefaultAsync<TaskItem>(query, new { Id = id });
        }

        public async Task CreateTaskAsync(TaskItem task)
        {
            string query = @"INSERT INTO Tasks (title, description, status, dueDate, createdOn)
                             OUTPUT INSERTED.id
                             VALUES (@Title, @Description, @Status, @DueDate, @CreatedOn);";
            int taskId = await _connection.ExecuteScalarAsync<int>(query, task);
            task.Id = taskId;
        }

        public async Task UpdateTaskAsync(int id, TaskItem task)
        {
            string query = @"UPDATE Tasks 
                             SET title = @Title, 
                                 description = @Description,
                                 status = @Status, 
                                 dueDate = @DueDate
                             WHERE id = @Id;";
            await _connection.ExecuteAsync(query, new
            {
                task.Title,
                task.Description,
                task.Status,
                task.DueDate,
                Id = id
            });
        }

        public async Task DeleteTaskAsync(int id)
        {
            string query = @"DELETE FROM Tasks WHERE id = @Id;";
            await _connection.ExecuteAsync(query, new { Id = id });
        }

        public async Task<bool> TaskExistsAsync(int id)
        {
            string query = @"SELECT 1 FROM Tasks WHERE id = @Id;";
            return await _connection.ExecuteScalarAsync<bool>(query, new { Id = id });
        }
    }
}
