using AutoMapper;
using Notes.DataTransferObjects.Notes;
using Notes.DataTransferObjects.NoteTags;
using Notes.Domain;

namespace Notes.Application.NoteTags;
public class NoteTagsMappingProfile : Profile
{   
    public NoteTagsMappingProfile()
    {
        CreateMap<NoteTagDto, NoteTag>()
            .ForMember(x => x.Id, opts => opts.MapFrom(op => op.Id))
            .ForMember(x => x.NoteId, opts => opts.MapFrom(op => op.NoteId))
            .ForMember(x => x.Title, opts => opts.MapFrom(op => op.Title))
            .ForMember(x => x.CreatedDate, opts => opts.MapFrom(op => op.CreatedDate))
            .ForMember(x => x.Color, opts => opts.MapFrom(op => op.Color));

        CreateMap<NoteTag, NoteTagDto>()
            .ForMember(x => x.Id, opts => opts.MapFrom(op => op.Id))
            .ForMember(x => x.NoteId, opts => opts.MapFrom(op => op.NoteId))
            .ForMember(x => x.Title, opts => opts.MapFrom(op => op.Title))
            .ForMember(x => x.CreatedDate, opts => opts.MapFrom(op => op.CreatedDate))
            .ForMember(x => x.Color, opts => opts.MapFrom(op => op.Color));

    }
}
