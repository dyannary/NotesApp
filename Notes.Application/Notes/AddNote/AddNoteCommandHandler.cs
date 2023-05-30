using AutoMapper;
using Notes.Application.Interfaces.Messaging;
using Notes.Domain;
using Notes.Persistence.Context;

namespace Notes.Application.Notes.AddNote;

public class AddNoteCommandHandler : ICommandHandler<AddNoteCommand, int>
{
    private readonly NotesDbContext _notesDbContext;
    private readonly IMapper _mapper;

    public AddNoteCommandHandler(NotesDbContext notesDbContext, IMapper mapper)
    {
        _notesDbContext = notesDbContext;
        _mapper = mapper;
    }
    public async Task<int> Handle(AddNoteCommand request, CancellationToken cancellationToken)
    {
        var noteToCreate = _mapper.Map<Note>(request.Data);

        await _notesDbContext.Notes.AddAsync(noteToCreate, cancellationToken);
        await _notesDbContext.SaveChangesAsync(cancellationToken);

        return noteToCreate.Id;
    }
}