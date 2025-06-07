using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Common.Mediator;
using TaskManager.Application.UseCases.User.CreateUser;
using TaskManager.Application.UseCases.User.LoginUser;

namespace TaskManager.Api.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    [HttpPost("Register")]
    public async Task<IActionResult> Register(
            [FromServices] IHandler<CreateUserRequest, CreateUserResponse> handler,
            [FromBody] CreateUserRequest request
        )
    {
        var result = await handler.Handle(request);

        return Ok(result);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Register(
            [FromServices] IHandler<LoginUserRequest, LoginUserResponse> handler,
            [FromBody] LoginUserRequest request
        )
    {
        var result = await handler.Handle(request);

        return Ok(result);
    }
}

