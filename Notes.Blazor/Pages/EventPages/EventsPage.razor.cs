using Microsoft.AspNetCore.Components;
using Notes.Blazor.Services.Implementations;
using Notes.Blazor.Services.Interfaces;
using Notes.DataTransferObjects.Events;
using Notes.DataTransferObjects.Notes;

namespace Notes.Blazor.Pages.EventPages
{
    public partial class EventsPage
    {
        [Inject]
        public IEventService EventService { get; set; }

        public IEnumerable<EventDto>? Events;
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;

        DateTime selectedDate = DateTime.Today;

        public bool ShowAllEvents = false;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Events = await EventService.GetEventsAsync();
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }

        private void NewEvent()
        {
            NavigationManager.NavigateTo("newEvent");
        }

        private void EventDetails(int id)
        {
            NavigationManager.NavigateTo($"eventDetails/{id}");
        }

        public IEnumerable<EventDto>? FilteredEvents()
        {
            if (ShowAllEvents)
                return Events;

            var result = Events.Where(e =>
                   e.StartDate.Date <= selectedDate &&
                   e.EndDate.Date >= selectedDate
            );

            return result;
        }

        private async Task HandleDataChanged(DateTime? data)
        {
            selectedDate = data.Value;
            await InvokeAsync(StateHasChanged); 
        }

        public void AllEvents()
        {
            ShowAllEvents = true;
        }
    }
}
