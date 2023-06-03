using Notes.Application.Interfaces.Messaging;
using Notes.DataTransferObjects.Events;

namespace Notes.Application.Events.GetEvents;

public record GetEventsQuery : IQuery<IEnumerable<EventDto>>;
