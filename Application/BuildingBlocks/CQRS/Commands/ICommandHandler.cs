using Domain;
using Domain.Common;
using MediatR;

namespace Application.BuildingBlocks.CQRS.Commands;

/// <summary>
///     Base interface, for all command handlers.
/// </summary>
/// <typeparam name="TCommand">Type of the command, that will be handled.</typeparam>
public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
}

/// <summary>
///     <inheritdoc cref="ICommandHandler{TCommand}" />
/// </summary>
/// <typeparam name="TCommand">
///     <inheritdoc cref="ICommandHandler{TCommand}" path="/typeparam" />
/// </typeparam>
/// <typeparam name="TResult">Type of the object, that will be returned as command execution result.</typeparam>
public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
}

/// <summary>
/// Defines a handler for a command request that produces a result.
/// </summary>
/// <typeparam name="TRequest">The type of command request being handled</typeparam>
public interface ICommandResultHandler<in TRequest> : ICommandHandler<TRequest, Result>
    where TRequest : ICommandResult
{
}

/// <summary>
/// Defines a handler for a command request that produces a result.
/// </summary>
/// <typeparam name="TRequest">The type of command request being handled</typeparam>
/// <typeparam name="TResponse"></typeparam>
public interface ICommandResultHandler<in TRequest, TResponse> : ICommandHandler<TRequest, Result<TResponse?>>
    where TRequest : ICommandResult<TResponse>
{
}