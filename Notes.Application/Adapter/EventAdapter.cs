using AutoMapper;
using Notes.DataTransferObjects.Events;
using Notes.Domain;

namespace Notes.Application.Adapter;

public class EventAdapter : ITypeConverter<AddEditEventDto, Event>, ITypeConverter<Event, EventDto>
{
    public Event Convert(AddEditEventDto source, Event destination, ResolutionContext context)
    {
        var @event = new Event
        {
            Id = source.Id,
            Name = source.Name,
            Description = source.Description,
            StartDate = source.StartDate,
            EndDate = source.EndDate,
            CreatedDate = source.CreatedDate,
            AllDay = source.AllDay
        };

        return @event;
    }

    public EventDto Convert(Event source, EventDto destination, ResolutionContext context)
    {
        var eventDto = new EventDto
        {
            Id = source.Id,
            Name = source.Name,
            Description = source.Description,
            StartDate = source.StartDate,
            EndDate = source.EndDate,
            CreatedDate = source.CreatedDate,
            AllDay = source.AllDay
        };

        return eventDto;
    }
}
