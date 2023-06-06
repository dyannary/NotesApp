namespace Notes.Domain;

public class NoteTag: Entity
{
    public string Title { get; set; } = string.Empty;
    public int Color { get; set; }

    public int NoteId { get; set; }
    public Note Note { get; set; } = null!;
}