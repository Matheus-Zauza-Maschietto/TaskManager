using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TaskManager.Application.Mediator;
using TaskManager.Application.Shared.DTOs;
using TaskManager.Application.Shared.Services.Contracts;
using TaskManager.Domain.Aggregates;
using TaskManager.Domain.Contracts;
using Core = TaskManager.Domain.Entities;

namespace TaskManager.Application.UseCases.Task.CreateTask;

public class CreateTaskHandle(
    [FromServices]ITaskRepository TaskRepository,
    [FromServices]IUserService UserService
) : IHandler<CreateTaskRequest, TaskDTO>
{
    public async Task<Result<TaskDTO>> Handle(CreateTaskRequest request)
    {
        User user = await UserService.GetRequestUser();

        Core.Task task = new Core.Task(user, request.Title, request.Description);

        Core.Task createdTask = await TaskRepository.CreateTaskAsync(task);

        await TaskRepository.SaveAsync();

        return Result<TaskDTO>.Success<TaskDTO>(TaskDTO.FromEntity(createdTask));
    }
}
