using Notes.Application.FactoryMethod;
using Notes.Application.Interfaces.Messaging;
using Notes.Domain;
using Notes.Persistence.Context;

namespace Notes.Application.Notes.AddNote;

public class AddNoteCommandHandler : ICommandHandler<AddNoteCommand, int>
{
    private readonly NotesDbContext _notesDbContext;

    public AddNoteCommandHandler(NotesDbContext notesDbContext)
    {
        _notesDbContext = notesDbContext;
    }
    public async Task<int> Handle(AddNoteCommand request, CancellationToken cancellationToken)
    {
        INoteFactory noteFactory = new NoteFactory(request.Data);

        var noteToCreate = (Note)noteFactory.Create();

        await _notesDbContext.Notes.AddAsync(noteToCreate, cancellationToken);
        await _notesDbContext.SaveChangesAsync(cancellationToken);

        return noteToCreate.Id;
    }
}