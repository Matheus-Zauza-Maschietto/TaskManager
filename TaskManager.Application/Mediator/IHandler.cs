using System;

namespace TaskManager.Application.Mediator;

public interface IHandler<TRequest, TResponse>
{
    Task<Result<TResponse>> Handle(TRequest request);
}
