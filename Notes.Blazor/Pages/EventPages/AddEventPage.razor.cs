using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;
using MudBlazor;
using Notes.Blazor.Services.Interfaces;
using Notes.DataTransferObjects.Notes;
using Notes.DataTransferObjects.Events;
using Notes.Blazor.Services.Implementations;

namespace Notes.Blazor.Pages.EventPages
{
    public partial class AddEventPage
    {
        [Inject]
        public IEventService EventService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        ISnackbar Snackbar { get; set; }

        [Inject]
        public DateStateService dateStateService { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; }

        public string EventName { get; set; } = "Name";
        
        public DateTime? EndDate { get; set; }
        public string EventDescription { get; set; } = "Description";
        public bool AllDay { get; set; }    

        public async Task SaveAndGoToEventDetails()
        {
            try
            {
                int id = await EventService.AddEventAsync(
                new AddEditEventDto()
                {
                    Name = EventName,
                    Description = EventDescription,
                    StartDate = (DateTime)dateStateService.SelectedDate,
                    EndDate = (DateTime)EndDate,
                    AllDay = AllDay
                });

                if (id == 0)
                    throw new Exception();
                else
                    NavigationManager.NavigateTo($"eventDetails/{id}");
            }
            catch (Exception)
            {
                Snackbar.Add("Can not create event");
            }
        }

        public void Cancel()
        { 
            NavigationManager.NavigateTo($"events");
        }
    }
}
