using System.Collections;
using Notes.DataTransferObjects.Tasks;

namespace Notes.Blazor.Decorator;

public class TaskList : ITaskListDecorator
{
    private readonly List<TaskDto> _tasks;

    public TaskList()
    {
        _tasks = new List<TaskDto>();
    }
    public TaskList(List<TaskDto> tasks)
    {
        _tasks = tasks;
    }

    public void Add(TaskDto task)
    {
        _tasks.Add(task);
    }

    public void RemoveTask(TaskDto task)
    {
        _tasks.Remove(task);
    }

    public List<TaskDto> GetTasks()
    {
        return _tasks;
    }

    public void InsertNewList(List<TaskDto> tasks)
    {
        _tasks.Clear();
        _tasks.AddRange(tasks);
    }
}