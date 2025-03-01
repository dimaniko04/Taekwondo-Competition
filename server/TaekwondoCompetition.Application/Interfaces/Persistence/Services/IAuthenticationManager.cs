using TaekwondoCompetition.Core.Entities;

namespace TaekwondoCompetition.Application.Interfaces.Services;

public interface IAuthenticationManager
{
    Task<User?> GetByEmailAsync(string email);
    Task AddUserAsync(User user, string password);
    Task AssignRoleAsync(User user, string roleName);
}
