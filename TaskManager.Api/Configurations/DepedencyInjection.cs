using System;
using TaskManager.Application.Mediator;
using TaskManager.Application.Shared.DTOs;
using TaskManager.Application.UseCases.Task.CreateTask;

namespace TaskManager.Api.Configurations;

public static class DepedencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IHandler<CreateTaskRequest, TaskDTO>, CreateTaskHandle>();

        return services;
    }
}
