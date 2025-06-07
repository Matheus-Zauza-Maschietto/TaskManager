using System;
using TaskManager.Application.Common.DTOs;
using TaskManager.Application.Common.Mediator;
using TaskManager.Application.Common.Services.Contracts;
using TaskManager.Domain.Aggregates;
using TaskManager.Domain.Contracts.Repositories;
using Core = TaskManager.Domain.Entities;
namespace TaskManager.Application.UseCases.Task.GetAllTask;

public class GetAllTaskHandle(
    ITaskRepository TaskRepository
) : IResponserHandler<List<TaskDTO>>
{
    public async Task<Result> Handle()
    {
        ICollection<Core.Task> tasks = await TaskRepository.GetTasksAsync();
        List<TaskDTO> taskDTOs = tasks.Select(t => TaskDTO.FromEntity(t)).ToList();

        return Result.Success(taskDTOs);
    }
}
