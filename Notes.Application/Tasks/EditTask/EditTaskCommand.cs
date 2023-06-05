using MediatR;
using Notes.DataTransferObjects.Tasks;

namespace Notes.Application.Tasks.EditTask;

public class EditTaskCommand : IRequest<int?>
{
    public AddEditTaskDto Data { get; set; }

    public EditTaskCommand(AddEditTaskDto data)
    {
        Data = data;
    }
}
