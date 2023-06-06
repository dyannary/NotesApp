using Notes.Application.Interfaces.Messaging;
using Notes.DataTransferObjects.NoteTags;

namespace Notes.Application.NoteTags.EditNoteTag;

public class EditNoteTagCommand : ICommand<int?>
{
    public NoteTagDto Data { get; set; }

    public EditNoteTagCommand(NoteTagDto data)
    {
        Data = data;
    }
}   