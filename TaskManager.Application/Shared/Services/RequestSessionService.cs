using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Shared.Services.Contracts;

namespace TaskManager.Application.Shared.Services;

public class RequestSessionService(
    [FromServices]IHttpContextAccessor HttpContextAccessor
) : IRequestSessionService
{
    public string GetUserEmail()
    {
        return HttpContextAccessor.HttpContext?.User?.FindFirst("email")?.Value ?? string.Empty;
    }
}
