using TaekwondoCompetition.Application.Requests;
using TaekwondoCompetition.Application.Responses;

namespace TaekwondoCompetition.Application.Interfaces.Services;

public interface IAuthenticationService
{
    Task<AuthResponse> LoginAsync(LoginRequest request);
    Task<AuthResponse> RegisterAsync(RegisterRequest request);
}