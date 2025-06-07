using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TaskManager.Application.Common.Mediator;
using TaskManager.Application.Common.DTOs;
using TaskManager.Application.Common.Services.Contracts;
using TaskManager.Domain.Aggregates;
using TaskManager.Domain.Contracts.Repositories;
using Core = TaskManager.Domain.Entities;
using TaskManager.Application.Common.Services.Contracts;

namespace TaskManager.Application.UseCases.Task.CreateTask;

public class CreateTaskHandle(
    [FromServices]ITaskRepository TaskRepository,
    [FromServices]IUnitOfWork UnitOfWork
) : IHandler<CreateTaskRequest, TaskDTO>
{
    public async Task<Result> Handle(CreateTaskRequest request)
    {
        Core.Task task = new Core.Task(request.Title, request.Description);

        Core.Task createdTask = await TaskRepository.CreateTaskAsync(task);

        await UnitOfWork.SaveChangesAsync();

        return Result.Success(TaskDTO.FromEntity(createdTask));
    }
}
