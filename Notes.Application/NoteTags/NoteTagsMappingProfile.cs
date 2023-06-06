using AutoMapper;
using Notes.Application.Adapter;
using Notes.DataTransferObjects.NoteTags;
using Notes.Domain;

namespace Notes.Application.NoteTags;
public class NoteTagsMappingProfile : Profile
{
    public NoteTagsMappingProfile()
    {
        CreateMap<NoteTagDto, NoteTag>().ConvertUsing<NoteTagsAdapter>();
        CreateMap<NoteTag, NoteTagDto>().ConvertUsing<NoteTagsAdapter>();
    }
}