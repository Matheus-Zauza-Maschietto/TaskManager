using Microsoft.AspNetCore.Builder;
using NSubstitute;
using System;
using System.Threading.Tasks;
using TaskManager.Application.Common.DTOs;
using TaskManager.Application.Common.Mediator;
using TaskManager.Application.Common.Services.Contracts;
using TaskManager.Application.UseCases.Task.CreateTask;
using TaskManager.Domain.Aggregates;
using TaskManager.Domain.Contracts.Repositories;
using Core = TaskManager.Domain.Entities;

namespace TaskManager.Tests;

public class CreateTaskHandleTest : IClassFixture<CreateTaskHandleTestFixture>
{
    private readonly IHandler<CreateTaskRequest, TaskDTO> Handler;

    public CreateTaskHandleTestFixture(IHandler<CreateTaskRequest, TaskDTO> handler)
    {
        Handler = handler;
    }

    [Fact]
    public async Task Handle_CreateTask_SuccessTaskCreation()
    {
        

        Result result = await handler.Handle(request);

        Assert.True(result.IsSucess);
    }
}
