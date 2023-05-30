using Notes.DataTransferObjects.Enums;

namespace Notes.DataTransferObjects.Notes;

public class AddEditNoteDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}