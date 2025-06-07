using Microsoft.AspNetCore.Identity;
using System;
using TaskManager.Application.Common.Mediator;
using TaskManager.Domain.Contracts.Repositories;
using Core = TaskManager.Domain.Aggregates;

namespace TaskManager.Application.UseCases.User.CreateUser;

public class CreateUserHandle(
    UserManager<Core.User> UserManager, 
    IUnitOfWork UnitOfWork
) : IHandler<CreateUserRequest, CreateUserResponse>
{
    public async Task<Result> Handle(CreateUserRequest request)
    {
        Core.User? user = await UserManager.FindByEmailAsync(request.Email);
        if (user is not null)
        {
            return Result.Failure("User with this email already exists.");
        }

        Core.User newUser = new Core.User(request.Email, request.FirstName, request.LastName);

        var result = await UserManager.CreateAsync(newUser, request.Password);
        if (!result.Succeeded) throw new Exception(string.Join("\n\n", result.Errors.Select(p => p.Description)));

        await UnitOfWork.SaveChangesAsync();

        return Result.Success(new CreateUserResponse(newUser.Email, newUser.UserName));
    }
}
