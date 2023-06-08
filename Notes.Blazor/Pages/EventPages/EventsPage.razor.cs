using Microsoft.AspNetCore.Components;
using MudBlazor;
using Notes.Blazor.Observer;
using Notes.Blazor.Services.Implementations;
using Notes.Blazor.Services.Interfaces;
using Notes.DataTransferObjects.Events;
using Notes.DataTransferObjects.Notes;
using System;
using System.Diagnostics.Tracing;

namespace Notes.Blazor.Pages.EventPages
{
    //Concrete Observer
    public partial class EventsPage
    {
        [Inject]
        public IEventService EventService { get; set; }

        public IEnumerable<EventDto>? Events;
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public DateStateService dateStateService { get; set; }
        
        public string ErrorMessage { get; set; } = string.Empty;

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
        private void EventDetailsReadOnly(int id)
        {
            NavigationManager.NavigateTo($"eventDetailsReadOnly/{id}");
        }

        public IEnumerable<EventDto>? FilteredEvents()
        {
            if (ShowAllEvents)
                return Events;

            var selectedDate = dateStateService.SelectedDate;

            var result = Events.Where(e =>
                   e.StartDate.Date <= selectedDate &&
                   e.EndDate.Date >= selectedDate
            );

            return result;
        }

        public void HandleDataChanged(DateTime? date)
        {
            if (date != null) dateStateService.SelectedDate = date.Value;
            StateHasChanged();
        }

        public void AllEvents()
        {
            ShowAllEvents = true;
        }
    }
}
