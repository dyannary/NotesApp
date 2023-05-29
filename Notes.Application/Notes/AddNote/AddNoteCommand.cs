using Notes.Application.Interfaces.Messaging;
using Notes.DataTransferObjects.Notes;

namespace Notes.Application.Notes.AddNote;

public class AddNoteCommand : ICommand<int>
{
    public AddNoteCommand(AddEditNoteDto data)
    {
        Data = data;   
    }
    public AddEditNoteDto Data { get; set; }
}