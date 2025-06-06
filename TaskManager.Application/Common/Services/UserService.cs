using Microsoft.AspNetCore.Mvc;
using System;
using TaskManager.Application.Common.Services.Contracts;
using TaskManager.Domain.Aggregates;
using TaskManager.Domain.Contracts.Repositories;

namespace TaskManager.Application.Common.Services;

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
