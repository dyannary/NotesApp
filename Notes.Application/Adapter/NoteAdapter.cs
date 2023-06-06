using AutoMapper;
using Notes.DataTransferObjects.Notes;
using Notes.Domain;

namespace Notes.Application.Adapter;

public class NoteAdapter : ITypeConverter<AddEditNoteDto, Note>, ITypeConverter<Note, NoteDto>
{
    public Note Convert(AddEditNoteDto source, Note destination, ResolutionContext context)
    {
        var note = new Note
        {
            Id = source.Id,
            Title = source.Title,
            Content = source.Content,
            CreatedDate = source.CreatedDate,
            Color = source.Color
        };

        return note;
    }

    public NoteDto Convert(Note source, NoteDto destination, ResolutionContext context)
    {
        var noteDto = new NoteDto
        {
            Id = source.Id,
            Title = source.Title,
            Content = source.Content,
            CreatedDate = source.CreatedDate,
            Color = source.Color
        };

        return noteDto;
    }
}
