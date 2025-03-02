using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TaekwondoCompetition.API.ActionFilters;
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
    [ServiceFilter(typeof(ValidationResultFilter))]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await _authenticationService.LoginAsync(request);

        return result.Match(
            () => Ok(result.Value),
            error => Problem(error));
    }

    [HttpPost("register")]
    [ServiceFilter(typeof(ValidationResultFilter))]
    public async Task<IActionResult> Register(
        [FromBody] RegisterRequest request,
        [FromServices] IValidator<RegisterRequest> validator)
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