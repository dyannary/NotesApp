using AutoMapper;
using Notes.DataTransferObjects.Notes;
using Notes.Domain;

namespace Notes.Application.Notes;

public class NoteMappingProfile : Profile
{
    public NoteMappingProfile()
    {
        CreateMap<AddEditNoteDto, Note>()
            .ForMember(x => x.Id, opts => opts.MapFrom(op => op.Id))
            .ForMember(x => x.Title, opts => opts.MapFrom(op => op.Title))
            .ForMember(x => x.Content, opts => opts.MapFrom(op => op.Content))
            .ForMember(x => x.CreatedDate, opts => opts.MapFrom(op => op.CreatedDate));

        CreateMap<Note, NoteDto>()
            .ForMember(x => x.Id, opts => opts.MapFrom(op => op.Id))
            .ForMember(x => x.Title, opts => opts.MapFrom(op => op.Title))
            .ForMember(x => x.Content, opts => opts.MapFrom(op => op.Content))
            .ForMember(x => x.CreatedDate, opts => opts.MapFrom(op => op.CreatedDate));
    }
}