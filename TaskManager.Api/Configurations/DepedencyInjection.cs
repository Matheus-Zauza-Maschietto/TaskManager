using System;
using TaskManager.Application.Common.Mediator;
using TaskManager.Application.Common.DTOs;
using TaskManager.Application.Common.Services;
using TaskManager.Application.Common.Services.Contracts;
using TaskManager.Application.UseCases.Task.CreateTask;
using TaskManager.Domain.Contracts.Repositories;
using TaskManager.Infra.PostgreSQL.Repositories;

namespace TaskManager.Api.Configurations;

public static class DepedencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRequestSessionService, RequestSessionService>();

        return services;
    }

    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddScoped<IHandler<CreateTaskRequest, TaskDTO>, CreateTaskHandle>();
        return services;
    }
}
