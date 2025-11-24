using MediatR;

namespace BuildingBlocks.CQRS;

public interface ICommandHandler<in T> : ICommandHandler<T, Unit> where T : ICommand<Unit>
{
}
public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
{
}