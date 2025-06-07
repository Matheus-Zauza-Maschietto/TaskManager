using Microsoft.AspNetCore.Mvc.Diagnostics;
using System;
using TaskManager.Domain.Contracts.Repositories;
using TaskManager.Application.Common.Services.Contracts;
using Core = TaskManager.Domain.Entities;

namespace TaskManager.Application.Common.Services;

public class TaskService(
    ITaskRepository TaskRepository
) : ITaskService
{
    public async Task<Core.Task> GetTaskByIdAsync(int taskId)
    {
        Core.Task? task = await TaskRepository.GetTaskByIdAsync(taskId);
        if (task == null)
        {
            throw new KeyNotFoundException($"Task with ID {taskId} not found.");
        }
        return task;
    }
}
