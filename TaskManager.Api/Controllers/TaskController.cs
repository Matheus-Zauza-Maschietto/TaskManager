using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Common.Mediator;
using TaskManager.Application.Common.DTOs;
using TaskManager.Application.UseCases.Task.CreateTask;
using TaskManager.Application.UseCases.Task.UpdateTask;
using TaskManager.Application.UseCases.Task.DeleteTask;
using Microsoft.AspNetCore.Authorization;

namespace TaskManager.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{

    [HttpPost()]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest request, [FromServices] IHandler<CreateTaskRequest, TaskDTO> handler)
    {

        var result = await handler.Handle(request);

        return result.IsSucess ? StatusCode(StatusCodes.Status201Created, result) : BadRequest(result);
    }

    [HttpGet()]
    public async Task<IActionResult> GetAllTasks([FromServices] IResponserHandler<List<TaskDTO>> handler)
    {
        var result = await handler.Handle();

        return result.IsSucess ? Ok(result) : BadRequest(result);
    }

    [HttpPatch("{TaskId}")]
    public async Task<IActionResult> UpdateTaskById(
        [FromServices] IHandler<UpdateTaskRequest, TaskDTO> handler,
        [FromBody] UpdateTaskRequest request)
    {
        var result = await handler.Handle(request);

        return result.IsSucess ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("{TaskId}")]
    public async Task<IActionResult> DeleteTaskById(
        [FromServices] IRequesterHandler<DeleteTaskRequest> handler,
        [FromRoute] DeleteTaskRequest request)
    {
        var result = await handler.Handle(request);

        return result.IsSucess ? NoContent() : BadRequest(result);
    }

}

