using TaekwondoCompetition.Application.Interfaces.Persistence.Services;
using TaekwondoCompetition.Core.Entities;

namespace TaekwondoCompetition.Persistence.Services;

public class TokenProvider : ITokenProvider
{
    public string GenerateToken(User user)
    {
        return "token";
    }
}