using Microsoft.AspNetCore.Mvc;
using System;
using TaskManager.Application.Shared.Services.Contracts;
using TaskManager.Domain.Aggregates;
using TaskManager.Domain.Contracts;

namespace TaskManager.Application.Shared.Services;

public class UserService(
    [FromServices]IRequestSessionService RequestSessionService,
    [FromServices]IUserRepository UserRepository
) : IUserService
{
    public async Task<User> GetRequestUser()
    {
        string? userEmail = RequestSessionService.GetUserEmail();
        ArgumentNullException.ThrowIfNull(userEmail, nameof(userEmail));
        return await UserRepository.GetUserByEmail(userEmail) ?? throw new KeyNotFoundException("User not found");
    }
}
