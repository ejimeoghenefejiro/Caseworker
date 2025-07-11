using Caseworker.Models;

namespace Caseworker.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<bool> Exists(string username)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserWithPasswordByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task Insert(User user, string password)
        {
            throw new NotImplementedException();
        }
    }
}
