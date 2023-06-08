using Notes.DataTransferObjects.Enums;
using Notes.DataTransferObjects.Tasks;

namespace Notes.Blazor.Decorator;
public class TaskListFilterByPriority : TaskListDecorator
{
    private readonly Priority _priority;

    public TaskListFilterByPriority(ITaskListDecorator tasks, Priority priority) : base(tasks)
    {
        _priority = priority;
    }

    public override List<TaskDto> GetTasks()
    {
        return _tasks.GetTasks().Where(t => t.Priority == _priority).ToList();
    }
}