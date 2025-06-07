using System;
using System.Security.Claims;

namespace TaskManager.Application.Common.Services.Contracts;

public interface IJWTService
{
    string GenerateToken(Claim[] claims);
}
