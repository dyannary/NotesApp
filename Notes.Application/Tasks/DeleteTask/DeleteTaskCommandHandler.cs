using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Persistence.Context;

namespace Notes.Application.Tasks.DeleteTask;

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Unit?>
{
    private readonly NotesDbContext _notesDbContext;

    public DeleteTaskCommandHandler(NotesDbContext notesDbContext)
    {
        _notesDbContext = notesDbContext;
    }
    public async Task<Unit?> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var taskToDelete = await _notesDbContext.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (taskToDelete == null)
        {
            return null;
        }

        _notesDbContext.Tasks.Remove(taskToDelete);

        await _notesDbContext.SaveChangesAsync();

        return Unit.Value;
    }
}
