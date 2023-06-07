using Notes.DataTransferObjects.Tasks;

namespace Notes.Blazor.Decorator;

public abstract class TaskListDecorator : ITaskListDecorator
{
    protected readonly ITaskListDecorator _tasks;

    protected TaskListDecorator(ITaskListDecorator tasks)
    {
        _tasks = tasks;
    }

    public abstract List<TaskDto> GetTasks();
    public void Add(TaskDto task)
    {
        _tasks.GetTasks().Add(task);
    }
}