using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces.Messaging;
using Notes.Domain;
using Notes.Persistence.Context;

namespace Notes.Application.NoteTags.AddNoteTag;

public class AddNoteTagCommandHandler : ICommandHandler<AddNoteTagCommand, int?>
{
    private readonly NotesDbContext _notesDbContext;

    public AddNoteTagCommandHandler(NotesDbContext notesDbContext)
    {
        _notesDbContext = notesDbContext;
    }
    public async Task<int?> Handle(AddNoteTagCommand request, CancellationToken cancellationToken)
    {
        var note = await _notesDbContext.Notes
            .FirstOrDefaultAsync(x => x.Id == request.Data.NoteId, cancellationToken: cancellationToken);

        if (note == null)
        {
            return null;
        }

        var noteTag = new NoteTag
        {
            CreatedDate = DateTime.Now,
            Title = request.Data.Title,
            Color = request.Data.Color
        };

        note.NoteTags.Add(noteTag);

        await _notesDbContext.NoteTags.AddAsync(noteTag, cancellationToken);
        await _notesDbContext.SaveChangesAsync(cancellationToken);

        return noteTag.Id;
    }
}