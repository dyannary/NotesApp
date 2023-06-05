using Notes.DataTransferObjects.Enums;

namespace Notes.DataTransferObjects.Notes;

public class AddEditNoteDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public string Color { get; set; } = string.Empty;
}