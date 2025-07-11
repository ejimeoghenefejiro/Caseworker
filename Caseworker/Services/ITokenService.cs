using Caseworker.Models;

namespace Caseworker.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
