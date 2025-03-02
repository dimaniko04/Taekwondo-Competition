using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TaekwondoCompetition.API.ActionFilters;

public class ValidationResultFilter : IActionFilter
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<ValidationResultFilter> _logger;

    public ValidationResultFilter(
        IServiceProvider serviceProvider,
        ILogger<ValidationResultFilter> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        foreach (var parameter in context.ActionDescriptor.Parameters)
        {
            if (parameter.BindingInfo?.BindingSource != BindingSource.Body)
            {
                continue;
            }

            var validator = _serviceProvider
                .GetService(typeof(IValidator<>)
                    .MakeGenericType(parameter.ParameterType)
                ) as IValidator;
            var subject = context.ActionArguments[parameter.Name];
            if (validator == null || subject == null)
            {
                continue;
            }

            var result = validator.Validate(
                new ValidationContext<object>(subject));

            if (!result.IsValid)
            {
                onValidationError(context, result);
                return;
            }
        }
    }

    private void onValidationError(
        ActionExecutingContext context,
        ValidationResult validationResult)
    {
        _logger.LogError("Validation error");

        var problemDetails = new ValidationProblemDetails(
            validationResult.ToDictionary())
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Validation failed",
            Detail = "One or more validation errors occurred",
            Instance = context.HttpContext.Request.Path
        };

        context.Result = new BadRequestObjectResult(problemDetails);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}