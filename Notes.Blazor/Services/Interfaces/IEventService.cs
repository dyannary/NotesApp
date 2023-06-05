using Notes.DataTransferObjects.Events;
using Notes.DataTransferObjects.Notes;

namespace Notes.Blazor.Services.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetEventsAsync();
        Task<EventDto> GetEventByIdAsync(int id);
        Task<int> AddEventAsync(AddEditEventDto myEvent);
        Task DeleteEventAsync(int id);
        Task PartialUpdateEventAsync(AddEditEventDto myEvent);
        Task UpdateEventAsync(AddEditEventDto myEvent);
    }
}
