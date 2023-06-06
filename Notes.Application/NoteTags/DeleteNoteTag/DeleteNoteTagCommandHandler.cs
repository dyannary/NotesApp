using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces.Messaging;
using Notes.Persistence.Context;

namespace Notes.Application.NoteTags.DeleteNoteTag;

public class DeleteNoteTagCommandHandler : ICommandHandler<DeleteNoteTagCommand, Unit?>
{
    private readonly NotesDbContext _notesDbContext;
    private readonly IMapper _mapper;
        
    public DeleteNoteTagCommandHandler(NotesDbContext notesDbContext, IMapper mapper)
    {
        _notesDbContext = notesDbContext;
        _mapper = mapper;
    }

    public async Task<Unit?> Handle(DeleteNoteTagCommand request, CancellationToken cancellationToken)
    {
        var noteEntity = await _notesDbContext.NoteTags.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        if (noteEntity is null)
        {
            return null;
        }   

        _notesDbContext.NoteTags.Remove(noteEntity);

        await _notesDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}