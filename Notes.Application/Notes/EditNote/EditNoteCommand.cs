using MediatR;
using Notes.DataTransferObjects.Notes;

namespace Notes.Application.Notes.EditNote;

public class EditNoteCommand : IRequest<int?>
{
    public AddEditNoteDto? Data { get; set; }

    public EditNoteCommand(AddEditNoteDto? data)
    {
        Data = data;
    }
}
