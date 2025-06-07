using System;
using TaskManager.Application.Common.DTOs;
using TaskManager.Application.Common.Mediator;
using TaskManager.Application.UseCases.Task.DeleteTask;
using TaskManager.Domain.Contracts.Repositories;
using TaskManager.Application.Common.Services.Contracts;
using Core = TaskManager.Domain.Entities;

namespace TaskManager.Application.UseCases.Task.UpdateTask;

public class UpdateTaskHandle(
    ITaskService TaskService,
    ITaskRepository TaskRepository,
    IUnitOfWork UnitOfWork
) : IHandler<UpdateTaskRequest, TaskDTO>
{
    public async Task<Result> Handle(UpdateTaskRequest request)
    {
        Core.Task task = await TaskService.GetTaskByIdAsync(request.TaskId);

        task.ChangeTask(request.Title, request.Description);
        await UnitOfWork.SaveChangesAsync();

        return Result.Success(TaskDTO.FromEntity(task));
    }
}
