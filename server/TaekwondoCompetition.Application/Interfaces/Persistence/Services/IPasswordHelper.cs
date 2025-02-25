using TaekwondoCompetition.Core.Entities;

namespace TaekwondoCompetition.Application.Interfaces.Persistence.Services;

public interface IPasswordHelper
{
    string HashPassword(User user, string password);
    bool VerifyPassword(User user, string hashedPassword, string password);
}