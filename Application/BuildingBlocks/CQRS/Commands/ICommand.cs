using Domain;
using MediatR;

namespace Application.BuildingBlocks.CQRS.Commands;

/// <summary>
///     Represents Command functionality in CQRS architecture approach.
///     <para><see href="https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs">Read more about CQRS</see>.</para>
/// </summary>
public interface ICommand : IRequest
{
}

/// <summary>
///     <inheritdoc cref="ICommand" />
///     <para>
///         <typeparamref name="TResult" /> is the type of the object, that will be returned as the command execution
///         result.
///     </para>
/// </summary>
/// <typeparam name="TResult">Type of the object, that will be returned as the command execution result.</typeparam>
public interface ICommand<out TResult> : IRequest<TResult>
{
}

/// <summary>
/// Represents a command that results in a response without specifying a response type.
/// Useful for scenarios where a command execution either succeeds or fails without returning additional data.
/// </summary>
public interface ICommandResult : ICommand<Result>{}

/// <summary>
/// Represents a command that results in a response without specifying a response type.
/// Useful for scenarios where a command execution either succeeds or fails without returning additional data.
/// </summary>
public interface ICommandResult<TResponse> : ICommand<Result<TResponse?>>{}