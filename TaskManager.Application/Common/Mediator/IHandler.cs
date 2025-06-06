using System;

namespace TaskManager.Application.Common.Mediator;

public interface IHandler<TRequest, TResponse>
{
    Task<Result<TResponse>> Handle(TRequest request);
}
