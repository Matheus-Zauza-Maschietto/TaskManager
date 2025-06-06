using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Common.Mediator;
using TaskManager.Application.Common.DTOs;
using TaskManager.Application.UseCases.Task.CreateTask;

namespace TaskManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{

    [HttpPost()]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest request, [FromServices]IHandler<CreateTaskRequest, TaskDTO> handler)
    {

        var result = await handler.Handle(request);

        return result.IsSucess ? Ok(result) : BadRequest(result);
    }
}

