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
        var taskToEdit = await _notesDbContext.Tasks.FirstOrDefaultAsync(x => x.Id == request.Data.Id);

        if (taskToEdit is null)
        {
            return null;
        }

        _mapper.Map(request.Data, taskToEdit);
        await _notesDbContext.SaveChangesAsync();

        return taskToEdit.Id;
    }
}
