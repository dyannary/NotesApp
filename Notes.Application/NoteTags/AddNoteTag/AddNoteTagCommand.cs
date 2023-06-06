using Notes.Application.Interfaces.Messaging;
using Notes.DataTransferObjects.Notes;
using Notes.DataTransferObjects.NoteTags;

namespace Notes.Application.NoteTags.AddNoteTag;

public class AddNoteTagCommand : ICommand<int?>
{
    public AddNoteTagCommand(NoteTagDto data)
    {
        Data = data;
    }
    public NoteTagDto Data { get; private set; }
}