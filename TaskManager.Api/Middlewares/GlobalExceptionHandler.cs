using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Net;
using TaskManager.Application.Common.Mediator;

namespace TaskManager.Api.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        Result result = Result.Failure(exception.Message);
        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        await httpContext.Response.WriteAsJsonAsync(result, cancellationToken);
        return true;
    }
}
