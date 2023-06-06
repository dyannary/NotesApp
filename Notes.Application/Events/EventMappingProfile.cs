using AutoMapper;
using Notes.Application.Adapter;
using Notes.DataTransferObjects.Events;
using Notes.Domain;

namespace Notes.Application.Events;

public class EventMappingProfile : Profile
{
    public EventMappingProfile()
    {
        CreateMap<AddEditEventDto, Event>().ConvertUsing<EventAdapter>();
        CreateMap<Event, EventDto>().ConvertUsing<EventAdapter>();
    }
}
