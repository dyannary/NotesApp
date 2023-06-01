using AutoMapper;
using Notes.DataTransferObjects.Events;
using Notes.Domain;

namespace Notes.Application.Events;

public class EventMappingProfile : Profile
{
    public EventMappingProfile()
    {
        CreateMap<AddEditEventDto, Event>()
            .ForMember(x => x.Id, opts => opts.MapFrom(op => op.Id))
            .ForMember(x => x.Name, opts => opts.MapFrom(op => op.Name))
            .ForMember(x => x.Description, opts => opts.MapFrom(op => op.Description))
            .ForMember(x => x.Date, opts => opts.MapFrom(op => op.Date));

        CreateMap<Event, EventDto>()
            .ForMember(x => x.Id, opts => opts.MapFrom(op => op.Id))
            .ForMember(x => x.Name, opts => opts.MapFrom(op => op.Name))
            .ForMember(x => x.Description, opts => opts.MapFrom(op => op.Description))
            .ForMember(x => x.Date, opts => opts.MapFrom(op => op.Date));
    }
}
