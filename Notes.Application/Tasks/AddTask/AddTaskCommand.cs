using Notes.Application.Interfaces.Messaging;
using Notes.DataTransferObjects.Tasks;

namespace Notes.Application.Tasks.AddTask;

public class AddTaskCommand : ICommand<int>
{
    public AddTaskCommand(AddEditTaskDto data)
    {
        Data = data;
    }
    public AddEditTaskDto Data { get; private set; }
}
