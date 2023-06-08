using MediatR;
using Notes.DataTransferObjects.Tasks;

namespace Notes.Application.Tasks.EditTask;

public class EditTaskCommand : IRequest<int?>
{
    public TaskDto Data { get; set; }

    public EditTaskCommand(TaskDto data)
    {
        Data = data;
    }
}
