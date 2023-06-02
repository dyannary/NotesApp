using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Persistence.Context;

namespace Notes.Application.Events.DeleteEvent;

public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, Unit>
{
    private readonly NotesDbContext _notesDbContext;

    public DeleteEventCommandHandler(NotesDbContext notesDbContext)
    {
        _notesDbContext = notesDbContext;
    }

    public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        var eventToDelete = await _notesDbContext.Events.FirstOrDefaultAsync(x => x.Id == request.Id);

        _notesDbContext.Events.Remove(eventToDelete);

        await _notesDbContext.SaveChangesAsync();

        return Unit.Value;
    }
}
