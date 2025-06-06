using System;

namespace TaskManager.Application.Shared.Services.Contracts;

public interface IRequestSessionService
{
    string GetUserEmail();
}
