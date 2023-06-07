using Notes.DataTransferObjects.Events;

namespace Notes.Blazor.Observer
{

    //Observer
    public interface IEventScheduledObserver
    {
        void Update(EventDto myEvent);
    }
}
