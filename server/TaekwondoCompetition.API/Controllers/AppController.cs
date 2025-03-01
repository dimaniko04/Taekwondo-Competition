using Microsoft.AspNetCore.Mvc;
using TaekwondoCompetition.Core.Errors;

namespace TaekwondoCompetition.API.Controllers;

public abstract class AppController : ControllerBase
{
    private readonly ILogger<AppController> _logger;

    protected AppController(ILogger<AppController> logger)
    {
        _logger = logger;
    }

    protected IActionResult Problem(AppError error)
    {
        _logger.LogError(error.Message);

        return Problem(
            statusCode: (int)error.Code,
            title: error.Message);
    }
}