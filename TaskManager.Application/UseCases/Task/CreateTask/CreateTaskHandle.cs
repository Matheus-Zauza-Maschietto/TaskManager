using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TaskManager.Application.Common.Mediator;
using TaskManager.Application.Common.DTOs;
using TaskManager.Application.Common.Services.Contracts;
using Aggre = TaskManager.Domain.Aggregates;
using TaskManager.Domain.Contracts.Repositories;
using Core = TaskManager.Domain.Entities;

namespace TaskManager.Application.UseCases.Task.CreateTask;

public class CreateTaskHandle(
    [FromServices] ITaskRepository TaskRepository,
    [FromServices] IUserService UserService,
    [FromServices] IUnitOfWork UnitOfWork
) : IHandler<CreateTaskRequest, TaskDTO>
{
    public async Task<Result> Handle(CreateTaskRequest request)
    {
        Aggre.User user = await UserService.GetRequestUser();

        Core.Task task = new Core.Task(request.Title, request.Description, user);

        Core.Task createdTask = await TaskRepository.CreateTaskAsync(task);

        await UnitOfWork.SaveChangesAsync();

        return Result.Success(TaskDTO.FromEntity(createdTask));
    }
}
