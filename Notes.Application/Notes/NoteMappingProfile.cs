using AutoMapper;
using Notes.DataTransferObjects.Notes;
using Notes.Domain;

namespace Notes.Application.Notes;

public class NoteMappingProfile : Profile
{
    public NoteMappingProfile()
    {
        CreateMap<AddEditNoteDto, Note>()
            .ForMember(x => x.Title, opts => opts.MapFrom(op => op.Title))
            .ForMember(x => x.Content, opts => opts.MapFrom(op => op.Content));

        CreateMap<Note, NoteDto>()
            .ForMember(x => x.Title, opts => opts.MapFrom(op => op.Title))
            .ForMember(x => x.Content, opts => opts.MapFrom(op => op.Content));
    }
}