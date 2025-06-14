using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Common.Services.Contracts;

namespace TaskManager.Application.Common.Services;

public class RequestSessionService(
    [FromServices] IHttpContextAccessor HttpContextAccessor
) : IRequestSessionService
{
    public string GetUserEmail()
    {
        return HttpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty;
    }
    
    public string GetUserId()
    {
        return HttpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
    }
}
