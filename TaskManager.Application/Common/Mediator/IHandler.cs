using System;

namespace TaskManager.Application.Common.Mediator;

public interface IHandler<TRequest, TResponse>
{
    Task<Result> Handle(TRequest request);
}

public interface IResponserHandler<TResponse>
{
    Task<Result> Handle();
}

public interface IRequesterHandler<TRequest>
{
    Task<Result> Handle(TRequest request);
}   
