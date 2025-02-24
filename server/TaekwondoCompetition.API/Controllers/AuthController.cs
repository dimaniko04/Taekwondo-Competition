using Microsoft.AspNetCore.Mvc;
using TaekwondoCompetition.Application.Requests;

namespace TaekwondoCompetition.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        return Ok(request);
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        return Ok(request);
    }
}