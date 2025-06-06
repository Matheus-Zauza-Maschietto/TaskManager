using System;

namespace TaskManager.Domain.Contracts;

public interface IBaseRepository
{
    Task SaveAsync();
}
