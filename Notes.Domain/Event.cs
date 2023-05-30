namespace Notes.Domain;

public class Event : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty; 
    public DateTime Date { get; set; }
}
