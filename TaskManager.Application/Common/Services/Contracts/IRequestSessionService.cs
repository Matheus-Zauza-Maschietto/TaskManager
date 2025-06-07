using System;

namespace TaskManager.Application.Common.Services.Contracts;

public interface IRequestSessionService
{
    string GetUserEmail();
    string GetUserId();
}
