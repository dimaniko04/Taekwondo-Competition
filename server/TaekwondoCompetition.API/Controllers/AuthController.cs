using Microsoft.AspNetCore.Mvc;
using TaekwondoCompetition.Application.Interfaces.Services;
using TaekwondoCompetition.Application.Requests;

namespace TaekwondoCompetition.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthController(IAuthenticationService authenticationService)
    {
        this._authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var authResponse = await _authenticationService.LoginAsync(request);

        return Ok(authResponse);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var authResponse = await _authenticationService.RegisterAsync(request);

        return Ok(authResponse);
    }
}