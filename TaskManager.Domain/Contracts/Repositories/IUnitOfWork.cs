using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Domain.Contracts.Repositories;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
    Task RollbackAsync();
    Task CommitAsync();
    bool HasChanges();
}
