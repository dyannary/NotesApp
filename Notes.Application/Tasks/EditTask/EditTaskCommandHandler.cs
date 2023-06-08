using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Notes.EditNote;
using Notes.Persistence.Context;

namespace Notes.Application.Tasks.EditTask;

public class EditTaskCommandHandler : IRequestHandler<EditTaskCommand, int?>
{
    private readonly NotesDbContext _notesDbContext;
    private readonly IMapper _mapper;

    public EditTaskCommandHandler(NotesDbContext notesDbContext, IMapper mapper)
    {
        _notesDbContext = notesDbContext;
        _mapper = mapper;
    }
    public async Task<int?> Handle(EditTaskCommand request, CancellationToken cancellationToken)
    {
        var taskToEdit = await _notesDbContext.Tasks.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken: cancellationToken);

        if (taskToEdit is null)
        {
            return null;
        }

        /*if (string.IsNullOrEmpty(request.Data.Title))
            taskToEdit.Title = request.Data.Title;
        if (string.IsNullOrEmpty(request.Data.Content))
            taskToEdit.Title = request.Data.Content;*/
        taskToEdit.IsCompleted = request.Data.IsCompleted;

        await _notesDbContext.SaveChangesAsync(cancellationToken);

        return taskToEdit.Id;
    }
}
