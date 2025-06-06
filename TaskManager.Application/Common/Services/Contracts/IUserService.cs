using System;
using TaskManager.Domain.Aggregates;

namespace TaskManager.Application.Common.Services.Contracts;

public interface IUserService
{
    Task<User> GetRequestUser();
}
