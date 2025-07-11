using Caseworker.Models;

namespace Caseworker.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsername(string username);
        Task<User> GetUserWithPasswordByUsername(string username);
        Task CreateTaskAsync(User user, string password);
        Task<bool> Exists(string username);
    }
}
