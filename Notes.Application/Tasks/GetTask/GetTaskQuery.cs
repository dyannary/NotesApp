using MediatR;
using Notes.DataTransferObjects.Tasks;

namespace Notes.Application.Tasks.GetTask;

public class GetTaskQuery : IRequest<TaskDto>
{
    public int Id { get; set; }
}
