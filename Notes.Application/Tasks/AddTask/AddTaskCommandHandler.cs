using AutoMapper;
using Notes.Application.Interfaces.Messaging;
using Notes.Persistence.Context;

namespace Notes.Application.Tasks.AddTask;

public class AddTaskCommandHandler : ICommandHandler<AddTaskCommand, int>
{
    private readonly NotesDbContext _notesDbContext;
    private readonly IMapper _mapper;

    public AddTaskCommandHandler(NotesDbContext notesDbContext, IMapper mapper)
    {
        _notesDbContext = notesDbContext;
        _mapper = mapper;
    }
    public async Task<int> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        var taskToCreate = _mapper.Map<Domain.Task>(request.Data);

        await _notesDbContext.Tasks.AddAsync(taskToCreate, cancellationToken);
        await _notesDbContext.SaveChangesAsync(cancellationToken);

        return taskToCreate.Id;
    }
}
