using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HexagonalCleanArchitecture.Api.Filtros;

public class UnhandledExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly ILogger<UnhandledExceptionFilterAttribute> _logger;

    public UnhandledExceptionFilterAttribute(ILogger<UnhandledExceptionFilterAttribute> logger)
    {
        _logger = logger;
    }

    public override void OnException(ExceptionContext context)
    {
        const string exceptionGeneral = "Exception";
        int statusCode;

        if (context != null)
        {
            statusCode = context.Exception.GetType().FullName == exceptionGeneral ?
                         (int)HttpStatusCode.InternalServerError :
                         (int)HttpStatusCode.BadRequest;

            // Customize this object to fit your needs
            var result = new ObjectResult(new
            {
                context.Exception.Message, // Or a different generic message
                context.Exception.Source,
                ExceptionType = context.Exception.GetType().FullName,
            })
            {
                StatusCode = statusCode
            };

            // Log the exception
            _logger.LogError("Unhandled exception occurred while executing request: {ex}", context.Exception);

            // Set the result
            context.Result = result;
        }
    }
}
