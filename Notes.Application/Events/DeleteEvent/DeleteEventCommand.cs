using MediatR;

namespace Notes.Application.Events.DeleteEvent;

public class DeleteEventCommand : IRequest<Unit?>
{
    public int Id { get; set; }
}
