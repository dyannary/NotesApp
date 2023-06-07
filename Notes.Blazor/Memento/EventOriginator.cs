using Notes.DataTransferObjects.Events;

namespace Notes.Blazor.Memento;

public class EventOriginator : EventDto
{

    public IEventMemento Save()
    {
        return new EventMemento(this);
    }

    public void Restore(IEventMemento memento)
    {
        var restoredEvent = memento.GetState();

        Id = restoredEvent.Id;
        Name = restoredEvent.Name;
        Description = restoredEvent.Description;
        StartDate = restoredEvent.StartDate;
        EndDate = restoredEvent.EndDate;
        CreatedDate = restoredEvent.CreatedDate;
    }
}