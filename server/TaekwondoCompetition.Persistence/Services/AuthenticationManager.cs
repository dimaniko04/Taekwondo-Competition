using TaekwondoCompetition.Application.Interfaces.Persistence.Services;
using TaekwondoCompetition.Application.Interfaces.Services;
using TaekwondoCompetition.Core.Entities;

namespace TaekwondoCompetition.Persistence.Services;

public class AuthenticationManager : IAuthenticationManager
{
    private readonly IPasswordHelper _passwordHasher;

    public AuthenticationManager(IPasswordHelper passwordHasher)
    {
        this._passwordHasher = passwordHasher;
    }

    public async Task AddUserAsync(User user, string password)
    {
        await Task.CompletedTask;
        user.Password = _passwordHasher.HashPassword(user, password);
    }

    public async Task AssignRoleAsync(User user, string roleName)
    {
        await Task.CompletedTask;
        var role = new Role
        {
            Name = roleName
        };
        user.Role = role;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        await Task.CompletedTask;

        if (email == "")
        {
            return null;
        }

        var user = new User
        {
            Email = email,
            Role = new Role
            {
                Name = "User"
            }
        };
        user.Password = _passwordHasher.HashPassword(user, "123456");

        return user;
    }
}
