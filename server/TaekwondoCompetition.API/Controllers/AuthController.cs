using Microsoft.AspNetCore.Mvc;
using TaekwondoCompetition.API.Extensions;
using TaekwondoCompetition.Application.Interfaces.Services;
using TaekwondoCompetition.Application.Requests;

namespace TaekwondoCompetition.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : AppController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthController(
        ILogger<AuthController> logger,
        IAuthenticationService authenticationService) : base(logger)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await _authenticationService.LoginAsync(request);

        return result.Match(
            () => Ok(result.Value),
            error => Problem(error));
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var result = await _authenticationService.RegisterAsync(request);

        return result.Match(
            () => Ok(result.Value),
            error => Problem(error));
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        throw new NotImplementedException("Test unhandled exception");
    }
}