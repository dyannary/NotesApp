using MediatR;

namespace Notes.Application.Notes.DeleteNote;

public class DeleteNoteCommand : IRequest<Unit?>
{
    public int Id { get; set; }
}
