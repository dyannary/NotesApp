namespace Notes.Domain;

public class Note : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
}