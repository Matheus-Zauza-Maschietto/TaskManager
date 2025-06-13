using NSubstitute;
using System;
using Core = TaskManager.Domain.Entities;
using TaskManager.Application.Common.DTOs;
using TaskManager.Application.Common.Mediator;
using TaskManager.Application.Common.Services.Contracts;
using TaskManager.Application.UseCases.Task.CreateTask;
using TaskManager.Domain.Contracts.Repositories;
using TaskManager.Domain.Aggregates;

namespace TaskManager.Tests;

public class CreateTaskHandleTestFixture
{
    public readonly IHandler<CreateTaskRequest, TaskDTO> Handler;

    public CreateTaskHandleTestFixture()
    {
        IUnitOfWork unitOfWork = Substitute.For<IUnitOfWork>();
        ITaskRepository taskRepository = Substitute.For<ITaskRepository>();
        IUserService userService = Substitute.For<IUserService>();


        Core.Task createdTask = null;
        User user = new User();
        user.Id = Guid.NewGuid().ToString();
        
        taskRepository.CreateTaskAsync(Arg.Any<Core.Task>()).Returns(callInfo =>
        {
            createdTask = callInfo.Arg<Core.Task>();
            createdTask.Id = 1;
            return Task.FromResult<Core.Task>(createdTask);
        });

        userService.GetRequestUser().Returns(Task.FromResult(user));

        Handler = new CreateTaskHandle(taskRepository, userService, unitOfWork);
    }
}
