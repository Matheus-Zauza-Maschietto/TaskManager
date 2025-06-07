using Microsoft.AspNetCore.Identity;
using System;
using TaskManager.Application.Common.Mediator;
using TaskManager.Domain.Contracts.Repositories;
using Core = TaskManager.Domain.Aggregates;

namespace TaskManager.Application.UseCases.User.CreateUser;

public class CreateUserHandle(
    IUserRepository UserRepository,
    UserManager<Core.User> UserManager, 
    IUnitOfWork UnitOfWork
) : IHandler<CreateUserRequest, CreateUserResponse>
{
    public async Task<Result> Handle(CreateUserRequest request)
    {
        Core.User? user = await UserRepository.GetUserByEmail(request.Email);
        if (user is not null)
        {
            return Result.Failure("User with this email already exists.");
        }

        Core.User newUser = new Core.User(request.Email, request.FirstName, request.LastName);

        await UserManager.CreateAsync(newUser, request.Password);

        await UnitOfWork.SaveChangesAsync();

        return Result.Success(new CreateUserResponse(user.Email, user.UserName));
    }
}
