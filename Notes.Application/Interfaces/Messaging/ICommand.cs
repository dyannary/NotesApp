using MediatR;

namespace Notes.Application.Interfaces.Messaging;

public interface ICommand<out TResponse> : IRequest<TResponse>
{

}

public interface ICommand : IRequest
{

}