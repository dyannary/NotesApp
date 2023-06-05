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
            .ForMember(x => x.StartDate, opts => opts.MapFrom(op => op.StartDate))
            .ForMember(x => x.EndDate, opts => opts.MapFrom(op => op.EndDate))
            .ForMember(x => x.CreatedDate, opts => opts.MapFrom(op => op.CreatedDate))
            .ForMember(x => x.AllDay, opts => opts.MapFrom(op => op.AllDay));

        CreateMap<Event, AddEditEventDto>()
            .ForMember(x => x.Id, opts => opts.MapFrom(op => op.Id))
            .ForMember(x => x.Name, opts => opts.MapFrom(op => op.Name))
            .ForMember(x => x.Description, opts => opts.MapFrom(op => op.Description))
            .ForMember(x => x.StartDate, opts => opts.MapFrom(op => op.StartDate))
            .ForMember(x => x.EndDate, opts => opts.MapFrom(op => op.EndDate))
            .ForMember(x => x.CreatedDate, opts => opts.MapFrom(op => op.CreatedDate))
            .ForMember(x => x.AllDay, opts => opts.MapFrom(op => op.AllDay));

        CreateMap<Event, EventDto>()
            .ForMember(x => x.Id, opts => opts.MapFrom(op => op.Id))
            .ForMember(x => x.Name, opts => opts.MapFrom(op => op.Name))
            .ForMember(x => x.Description, opts => opts.MapFrom(op => op.Description))
            .ForMember(x => x.StartDate, opts => opts.MapFrom(op => op.StartDate))
            .ForMember(x => x.EndDate, opts => opts.MapFrom(op => op.EndDate))
            .ForMember(x => x.CreatedDate, opts => opts.MapFrom(op => op.CreatedDate))
            .ForMember(x => x.AllDay, opts => opts.MapFrom(op => op.AllDay));
    }
}
