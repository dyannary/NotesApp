namespace Notes.Blazor.Memento;

public class EventMemento : IEventMemento
{
    private readonly EventOriginator _originator;

    public EventMemento(EventOriginator originator)
    {
        _originator = new EventOriginator
        {
            Id = originator.Id,
            Name = originator.Name,
            Description = originator.Description,
            StartDate = originator.StartDate,
            EndDate = originator.EndDate,
            CreatedDate = originator.CreatedDate
        };
    }

    public EventOriginator GetState()
    {
        return _originator;
    }
}