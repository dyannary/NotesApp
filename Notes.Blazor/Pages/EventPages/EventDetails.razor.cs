using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.JsonPatch;
using MudBlazor;
using Newtonsoft.Json;
using Notes.Blazor.Services.Interfaces;
using Notes.DataTransferObjects.Events;
using Notes.DataTransferObjects.Notes;
using System.ComponentModel;
using System.Text;

namespace Notes.Blazor.Pages.EventPages
{
    public partial class EventDetails
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IEventService EventService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public EventDto? Event { get; set; }

        private DateTime? StartDateNullable
        {
            get => Event.StartDate;
            set => Event.StartDate = value ?? DateTime.MinValue; // Set a default value if null is assigned
        }

        private DateTime? EndDateNullable
        {
            get => Event.EndDate;
            set => Event.EndDate = value ?? DateTime.MinValue; // Set a default value if null is assigned
        }

        public string ErrorMessage { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Event = await EventService.GetEventByIdAsync(Id);
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }

        public async Task SaveAndGoToEventPage()
        {
            try
            {
                AddEditEventDto addEditEventDto = new AddEditEventDto()
                { 
                    Id = Event.Id,
                    Name = Event.Name,
                    StartDate = StartDateNullable.Value,
                    EndDate = EndDateNullable.Value,
                    Description = Event.Description,
                    CreatedDate = Event.CreatedDate,
                    AllDay = Event.AllDay
                };

                await EventService.UpdateEventAsync(addEditEventDto);
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }

        public async Task ChangeEventName()
        {

        }

        public async Task ChangeEventContent()
        {

        }

        private void GoToNotePage()
        {
            NavigationManager.NavigateTo("events");
        }
    }
}
