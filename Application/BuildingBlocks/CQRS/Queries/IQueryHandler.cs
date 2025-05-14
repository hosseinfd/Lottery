using Domain;
using MediatR;

namespace Application.BuildingBlocks.CQRS.Queries;

/// <summary>
///     Base interface, for all query handlers.
/// </summary>
/// <typeparam name="TQuery">Type of the query, that will be handled.</typeparam>
/// <typeparam name="TResult">Type of the object, that will be returned as query execution result.</typeparam>
public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}

/// <summary>
/// Defines a handler for processing queries of type <typeparamref name="TRequest"/> and returning a result of type <typeparamref name="TResponse"/>.
/// </summary>
/// <typeparam name="TRequest">The type of the query request.</typeparam>
/// <typeparam name="TResponse">The type of the response that is returned after processing the query.</typeparam>
public interface IQueryResultHandler<in TRequest, TResponse> : IQueryHandler<TRequest, Result<TResponse?>>
    where TRequest : IQueryResult<TResponse>{}