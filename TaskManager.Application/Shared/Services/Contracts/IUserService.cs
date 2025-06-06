using System;
using TaskManager.Domain.Aggregates;

namespace TaskManager.Application.Shared.Services.Contracts;

public interface IUserService
{
    Task<User> GetRequestUser();
}
