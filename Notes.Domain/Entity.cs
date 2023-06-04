namespace Notes.Domain;

public abstract class Entity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
}