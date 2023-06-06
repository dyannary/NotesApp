using AutoMapper;
using Notes.Application.Adapter;
using Notes.DataTransferObjects.Notes;
using Notes.Domain;

namespace Notes.Application.Notes;

public class NoteMappingProfile : Profile
{
    public NoteMappingProfile()
    {
        CreateMap<AddEditNoteDto, Note>().ConvertUsing<NoteAdapter>();
        CreateMap<Note, NoteDto>().ConvertUsing<NoteAdapter>();
    }
}