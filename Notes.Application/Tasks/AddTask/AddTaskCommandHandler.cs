using Notes.Application.FactoryMethod;
using Notes.Application.Interfaces.Messaging;
using Notes.Persistence.Context;

namespace Notes.Application.Tasks.AddTask;

public class AddTaskCommandHandler : ICommandHandler<AddTaskCommand, int>
{
    private readonly NotesDbContext _notesDbContext;

    public AddTaskCommandHandler(NotesDbContext notesDbContext)
    {
        _notesDbContext = notesDbContext;
    }
    public async Task<int> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        INoteFactory taskFactory = new FactoryMethod.TaskFactory(request.Data);

        var taskToCreate = (Domain.Task)taskFactory.Create();

        await _notesDbContext.Tasks.AddAsync(taskToCreate, cancellationToken);
        await _notesDbContext.SaveChangesAsync(cancellationToken);

        return taskToCreate.Id;
    }
}
