using Notes.DataTransferObjects.Enums;
using Notes.DataTransferObjects.Tasks;

namespace Notes.Blazor.Decorator;
public class TaskListFilterByHighPriority : TaskListDecorator
{
    public TaskListFilterByHighPriority(ITaskListDecorator tasks) : base(tasks)
    {
    }

    public override List<TaskDto> GetTasks()
    {
        return _tasks.GetTasks().Where(t => t.Priority == Priority.High).ToList();
    }
}