using System.Collections;
using Notes.DataTransferObjects.Tasks;

namespace Notes.Blazor.Decorator;

public interface ITaskListDecorator
{
    List<TaskDto> GetTasks();

    void Add(TaskDto task);
}