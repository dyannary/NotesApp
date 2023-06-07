using AutoMapper;
using Notes.DataTransferObjects.Events;
using Notes.Domain;

namespace Notes.Application.Adapter;

public class EventAdapter : ITypeConverter<AddEditEventDto, Event>, ITypeConverter<Event, EventDto>
{
    public Event Convert(AddEditEventDto source, Event destination, ResolutionContext context)
    {
        destination.Id = source.Id;
        destination.Name = source.Name;
        destination.Description = source.Description;
        destination.StartDate = source.StartDate;
        destination.EndDate = source.EndDate;
        destination.CreatedDate = source.CreatedDate;
        destination.AllDay = source.AllDay;

        return destination;
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
