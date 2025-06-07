using System;
using TaskManager.Application.Common.Mediator;
using TaskManager.Application.Common.DTOs;
using TaskManager.Application.Common.Services;
using TaskManager.Application.Common.Services.Contracts;
using TaskManager.Application.UseCases.Task.CreateTask;
using TaskManager.Domain.Contracts.Repositories;
using TaskManager.Infra.PostgreSQL.Repositories;
using TaskManager.Application.UseCases.Task.GetAllTask;
using TaskManager.Application.UseCases.Task.DeleteTask;
using TaskManager.Application.UseCases.User.CreateUser;
using TaskManager.Application.UseCases.Task.UpdateTask;
using TaskManager.Application.UseCases.User.LoginUser;

namespace TaskManager.Api.Configurations;

public static class DepedencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRequestSessionService, RequestSessionService>();
        services.AddScoped<ITaskService, TaskService>();
        services.AddScoped<IJWTService, JWTService>();

        return services;
    }

    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddScoped<IHandler<CreateTaskRequest, TaskDTO>, CreateTaskHandle>();
        services.AddScoped<IResponserHandler<List<TaskDTO>>, GetAllTaskHandle>();
        services.AddScoped<IHandler<UpdateTaskRequest, TaskDTO>, UpdateTaskHandle>();
        services.AddScoped<IRequesterHandler<DeleteTaskRequest>, DeleteTaskHandle>();
        services.AddScoped<IHandler<CreateUserRequest, CreateUserResponse>, CreateUserHandle>();
        services.AddScoped<IHandler<LoginUserRequest, LoginUserResponse>, LoginUserHandle>();

        return services;
    }
}
