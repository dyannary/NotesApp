using MediatR;
using Notes.DataTransferObjects.Events;

namespace Notes.Application.Events.GetEvent;

public class GetEventQuery : IRequest<EventDto>
{
    public int Id { get; set; }
}
