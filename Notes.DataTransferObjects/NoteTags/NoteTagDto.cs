using Notes.DataTransferObjects.Notes;

namespace Notes.DataTransferObjects.NoteTags;
    
public class NoteTagDto
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Color { get; set; }

    public int NoteId { get; set; }
}