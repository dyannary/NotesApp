using MediatR;

namespace Notes.Application.Interfaces.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
where TQuery : IQuery<TResponse>
{

}

public interface IQueryHandler<in TQuery> : IRequestHandler<TQuery>
    where TQuery : IQuery
{

}