using AutoMapper;
using Notes.DataTransferObjects.NoteTags;
using Notes.Domain;

namespace Notes.Application.Adapter;

public class NoteTagsAdapter : ITypeConverter<NoteTagDto, NoteTag>, ITypeConverter<NoteTag, NoteTagDto>
{
    public NoteTag Convert(NoteTagDto source, NoteTag destination, ResolutionContext context)
    {
        var noteTag = new NoteTag
        {
            Id = source.Id,
            NoteId = source.NoteId,
            Title = source.Title,
            CreatedDate = source.CreatedDate,
            Color = source.Color
        };

        return noteTag;
    }

    public NoteTagDto Convert(NoteTag source, NoteTagDto destination, ResolutionContext context)
    {
        var noteTagDto = new NoteTagDto
        {
            Id = source.Id,
            NoteId = source.NoteId,
            Title = source.Title,
            CreatedDate = source.CreatedDate,
            Color = source.Color
        };

        return noteTagDto;
    }
}