using MediatR;

namespace Notes.Application.Interfaces.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse>
{

}

public interface IQuery : IRequest
{

}