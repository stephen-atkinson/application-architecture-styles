using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DonutShop.Api.ExceptionHandlers;

public class ValidationExceptionHandler : IExceptionHandler
{
    private readonly IProblemDetailsService _problemDetailsService;

    public ValidationExceptionHandler(IProblemDetailsService problemDetailsService)
    {
        _problemDetailsService = problemDetailsService;
    }
    
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not ValidationException validationException)
        {
            return false;
        }

        var context = new ProblemDetailsContext
        {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails = new ProblemDetails
            {
                Status = httpContext.Response.StatusCode = StatusCodes.Status400BadRequest,
                Type = "ValidationFailure",
                Title = "One or more validation errors occurred.",
                Extensions = new Dictionary<string, object?>
                {
                    ["errors"] = validationException.Errors.ToDictionary(e => e.PropertyName, e => e.ErrorMessage)
                }
            }
        };

        await _problemDetailsService.WriteAsync(context);

        return true;
    }
}