using Microsoft.AspNetCore.Mvc;

namespace TaekwondoCompetition.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    [HttpGet]
    public IActionResult Test()
    {
        return Ok("Test");
    }
}