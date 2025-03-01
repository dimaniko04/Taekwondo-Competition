using TaekwondoCompetition.Application.Interfaces.Persistence.Services;
using TaekwondoCompetition.Application.Interfaces.Services;
using TaekwondoCompetition.Application.Requests;
using TaekwondoCompetition.Application.Responses;
using TaekwondoCompetition.Core.Entities;
using TaekwondoCompetition.Core.Errors;
using TaekwondoCompetition.Core.Result;

namespace TaekwondoCompetition.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthenticationManager _authenticationManager;
    private readonly IPasswordHelper _passwordHasher;
    private readonly ITokenProvider _tokenProvider;

    public AuthenticationService(
        IAuthenticationManager authenticationManager,
        IPasswordHelper passwordHasher,
        ITokenProvider tokenProvider)
    {
        this._authenticationManager = authenticationManager;
        this._passwordHasher = passwordHasher;
        this._tokenProvider = tokenProvider;
    }

    public async Task<Result<AuthResponse>> LoginAsync(LoginRequest request)
    {
        var user = await _authenticationManager.GetByEmailAsync(request.Email);

        if (user == null)
        {
            return Result<AuthResponse>
                .Failure(Errors.Authentication.UserNotFound);
        }

        if (!_passwordHasher.VerifyPassword(user, user.Password, request.Password))
        {
            return Result<AuthResponse>
                .Failure(Errors.Authentication.InvalidCredentials);
        }

        var token = _tokenProvider.GenerateToken(user);
        var authResponse = new AuthResponse(
            token,
            new UserResponse(
                user.Id,
                user.Email,
                user.Role.Name
            )
        );

        return Result<AuthResponse>.Success(authResponse);
    }

    public async Task<Result<AuthResponse>> RegisterAsync(RegisterRequest request)
    {
        var user = new User
        {
            Email = request.Email,
        };

        await _authenticationManager.AddUserAsync(user, request.Password);
        await _authenticationManager.AssignRoleAsync(user, "User");

        var token = _tokenProvider.GenerateToken(user);
        var authResponse = new AuthResponse(
            token,
            new UserResponse(
                user.Id,
                user.Email,
                user.Role.Name
            )
        );

        return Result<AuthResponse>.Success(authResponse);
    }
}