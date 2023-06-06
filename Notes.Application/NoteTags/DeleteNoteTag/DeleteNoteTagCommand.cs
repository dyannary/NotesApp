using MediatR;
using Notes.Application.Interfaces.Messaging;

namespace Notes.Application.NoteTags.DeleteNoteTag;

public class DeleteNoteTagCommand : ICommand<Unit?>
{
    public int Id { get; set; }

    public DeleteNoteTagCommand(int id)
    {
        Id = id;
    }
}   