using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;
using TaskManager.Application.Common.Mediator;
using TaskManager.Application.Common.Services.Contracts;
using TaskManager.Domain.Contracts.Repositories;
using Core = TaskManager.Domain.Aggregates;

namespace TaskManager.Application.UseCases.User.LoginUser;

public class LoginUserHandle(
    IUserRepository UserRepository,
    UserManager<Core.User> UserManager,
    IJWTService JWTService
) : IHandler<LoginUserRequest, LoginUserResponse>
{

    public async Task<Result> Handle(LoginUserRequest request)
    {
        Core.User? user = await UserRepository.GetUserByEmail(request.Email);
        if (user is null)
        {
            return Result.Failure("User with this email does not exist.");
        }

        if (!await UserManager.CheckPasswordAsync(user, request.Password))
        {
            return Result.Failure("Invalid password.");
        }

        string token = JWTService.GenerateToken(new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
        });

        return Result.Success(new LoginUserResponse(token));
    }
}
