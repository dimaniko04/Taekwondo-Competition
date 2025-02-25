using TaekwondoCompetition.Core.Entities;

namespace TaekwondoCompetition.Application.Interfaces.Persistence.Services;

public interface ITokenProvider
{
    string GenerateToken(User user);
}