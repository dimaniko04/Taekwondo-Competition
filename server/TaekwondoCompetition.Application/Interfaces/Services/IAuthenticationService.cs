using TaekwondoCompetition.Application.Requests;
using TaekwondoCompetition.Application.Responses;
using TaekwondoCompetition.Core.Result;

namespace TaekwondoCompetition.Application.Interfaces.Services;

public interface IAuthenticationService
{
    Task<Result<AuthResponse>> LoginAsync(LoginRequest request);
    Task<Result<AuthResponse>> RegisterAsync(RegisterRequest request);
}