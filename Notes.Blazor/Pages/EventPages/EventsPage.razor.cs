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
    public partial class EventsPage : IEventScheduledObserver
    {
        [Inject]
        public IEventService EventService { get; set; }

        public IEnumerable<EventDto>? Events;
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public DateStateService dateStateService { get; set; }

        [Inject] private IDialogService DialogService { get; set; }

        public ISnackbar Snackbar { get; set; }
        //{
        //    get => Snackbar;
        //    set
        //    {
        //        Snackbar = value;
        //        eventCalendar?.Attach(this); // Attach the observer when the Snackbar is injected
        //    }
        //}

        public string ErrorMessage { get; set; } = string.Empty;

        public bool ShowAllEvents = false;

        private EventCalendar eventCalendar; // Concrete subject

        protected override async Task OnInitializedAsync()
        {
            try
            {
                eventCalendar = new EventCalendar();

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

        public void OnDateSelectedChanged(DateTime? date)
        {
            if (date != null) dateStateService.SelectedDate = date.Value;
            StateHasChanged();
        }

        public void AllEvents()
        {
            ShowAllEvents = true;
        }

        public void AddSnackbar()
        {
        }

        public void AddCloseAfterNavSnackbar()
        {
            Snackbar.Add("Will close after navigation.", Severity.Normal, (options) =>
            {
                options.CloseAfterNavigation = true;
            });
        }

        public void Update(EventDto myEvent)
        {
            //string state = "Message box hasn't been opened yet";
            //Snackbar.Add($"Event '{myEvent.Name}' is starting in one day!", Severity.Info);
            //bool? result = await DialogService.ShowMessageBox(
            //    "Warning",
            //    "Deleting can not be undone!",
            //    yesText: "Delete!", cancelText: "Cancel");
            //state = result == null ? "Canceled" : "Deleted!";
            // StateHasChanged();

            Snackbar.Add("Remains open after navigation.", Severity.Normal);

            StateHasChanged();
        }
    }
}
