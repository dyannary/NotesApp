using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Persistence.Context;

namespace Notes.Application.Notes.DeleteNote;

public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Unit?>
{
    private readonly NotesDbContext _notesDbContext;

    public DeleteNoteCommandHandler(NotesDbContext notesDbContext)
    {
        _notesDbContext = notesDbContext;
    }
    public async Task<Unit?> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var noteToDelete = await _notesDbContext.Notes.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (noteToDelete == null)
        {
            return null;
        }

        _notesDbContext.Notes.Remove(noteToDelete);

        await _notesDbContext.SaveChangesAsync();

        return Unit.Value;
    }
}
