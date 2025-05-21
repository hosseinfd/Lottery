using Domain;
using Domain.Common;
using MediatR;

namespace Application.BuildingBlocks.CQRS.Queries;

/// <summary>
///     Represents Query functionality in CQRS architecture approach.
///     <para><see href="https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs">Read more about CQRS</see>.</para>
/// </summary>
/// <typeparam name="TResult">Type of the object, that will be returned as the command execution result.</typeparam>
public interface IQuery<out TResult> : IRequest<TResult>
{
}

/// <summary>
/// Represents a query within the application that returns a response of type <typeparamref name="TResponse"/>.
/// </summary>
/// <typeparam name="TResponse">The type of the response that the query will return.</typeparam>
public interface IQueryResult<TResponse> : IQuery<Result<TResponse?>>{}