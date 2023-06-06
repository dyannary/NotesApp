using Notes.DataTransferObjects.NoteTags;

namespace Notes.DataTransferObjects.Notes;

public class NoteDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public string Color { get; set; } = string.Empty;
    public List<NoteTagDto> NoteTags { get; set; } = new ();


    public NoteDto Clone()
    {
        var noteTags = new List<NoteTagDto>();
        foreach (var noteTag in NoteTags)
        {
            noteTags.Add(noteTag);
        }

        return new NoteDto()
        {
            Id = Id,
            Title = Title,
            Content = Content,
            CreatedDate = CreatedDate,
            Color = Color,
            NoteTags = noteTags
        };
    }
}