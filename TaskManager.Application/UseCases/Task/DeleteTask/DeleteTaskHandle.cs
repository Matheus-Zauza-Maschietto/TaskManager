using Microsoft.AspNetCore.Mvc;
using System;
using TaskManager.Application.Common.Mediator;
using TaskManager.Domain.Contracts.Repositories;
using TaskManager.Application.Common.Services.Contracts;
using Core = TaskManager.Domain.Entities;

namespace TaskManager.Application.UseCases.Task.DeleteTask;

public class DeleteTaskHandle
(
    [FromServices]ITaskRepository TaskRepository,
    [FromServices] ITaskService TaskService,
    [FromServices]IUnitOfWork UnitOfWork
) : IRequesterHandler<DeleteTaskRequest>
{

    public async Task<Result> Handle(DeleteTaskRequest request)
    {
        Core.Task task = await TaskService.GetTaskByIdAsync(request.TaskId);
        await TaskRepository.DeleteTaskAsync(task);
        await UnitOfWork.SaveChangesAsync();

        return Result.Success("Task deleted successfully.");
    }
}
