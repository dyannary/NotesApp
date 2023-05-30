using MediatR;

namespace Notes.Application.Tasks.DeleteTask;

public class DeleteTaskCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
