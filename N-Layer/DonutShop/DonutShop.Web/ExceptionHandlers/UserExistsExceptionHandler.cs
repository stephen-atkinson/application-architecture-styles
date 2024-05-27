using DonutShop.BLL.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DonutShop.Web.ExceptionHandlers;

public class UserExistsExceptionHandler : IExceptionHandler
{
    private readonly IProblemDetailsService _problemDetailsService;

    public UserExistsExceptionHandler(IProblemDetailsService problemDetailsService)
    {
        _problemDetailsService = problemDetailsService;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not UserExistsException userExistsException)
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
                Title = "User already exists.",
                Detail = $"User with the username \"{userExistsException.Username}\" already exists"
            }
        };

        await _problemDetailsService.WriteAsync(context);

        return true;
    }
}