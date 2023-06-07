using Notes.DataTransferObjects.Tasks;

namespace Notes.Blazor.Decorator;
public class TaskListOrderByPriority : TaskListDecorator
{
    private readonly bool _descending;

    public TaskListOrderByPriority(ITaskListDecorator tasks, bool order = false) : base(tasks)
    {
        _descending = order;
    }

    public override List<TaskDto> GetTasks()
    {
        if (_descending)
        {
            return _tasks.GetTasks().OrderByDescending(t => t.Priority).ToList();
        }
        return _tasks.GetTasks().OrderBy(t => t.Priority).ToList();
    }
}