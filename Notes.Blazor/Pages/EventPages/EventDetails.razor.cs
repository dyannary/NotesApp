using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.JsonPatch;
using MudBlazor;
using Newtonsoft.Json;
using Notes.Blazor.Services.Implementations;
using Notes.Blazor.Services.Interfaces;
using Notes.DataTransferObjects.Events;
using Notes.DataTransferObjects.Notes;
using System.ComponentModel;
using System.Text;
using Notes.Blazor.Memento;
using System.Xml.Linq;

namespace Notes.Blazor.Pages.EventPages
{
    public partial class EventDetails
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IEventRepository EventRepository { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IDialogService DialogService { get; set; }

        public EventOriginator? Event { get; set; }

        public IEventMemento EventMemento { get; set; }

        private DateTime? StartDateNullable
        {
            get => Event.StartDate;
            set => Event.StartDate = value ?? DateTime.MinValue; 
        }

        private DateTime? EndDateNullable
        {
            get => Event.EndDate;
            set => Event.EndDate = value ?? DateTime.MinValue;
        }

        public string ErrorMessage { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var @event = await EventRepository.GetEventByIdAsync(Id);

                if (@event != null)
                {
                    Event = new EventOriginator
                    {
                        Id = @event.Id,
                        Name = @event.Name,
                        Description = @event.Description,
                        StartDate = @event.StartDate,
                        EndDate = @event.EndDate,
                        CreatedDate = @event.CreatedDate
                    };
                }

                SaveMemento();
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
                await SaveEventToDb();

                NavigationManager.NavigateTo($"events");
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }

        private async Task SaveEventToDb()
        {
            var addEditEventDto = new AddEditEventDto()
            {
                Id = Event.Id,
                Name = Event.Name,
                StartDate = StartDateNullable.Value,
                EndDate = EndDateNullable.Value,
                Description = Event.Description,
                CreatedDate = Event.CreatedDate,
                AllDay = Event.AllDay
            };

            await EventRepository.UpdateEventAsync(addEditEventDto);
        }

        public async Task Cancel()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var result = await DialogService.Show<AlertDialog>("Discard changes ?", options).Result;

            if (!result.Cancelled)
            {
                Undo();

                await SaveEventToDb();

                NavigationManager.NavigateTo($"events");
            }
        }

        private async Task GoToEventPage()
        {
            await SaveEventToDb();
            NavigationManager.NavigateTo("events");
        }

        private void Undo()
        {
            Event.Restore(EventMemento);
        }

        private void SaveMemento()
        {
            EventMemento = Event.Save();
        }
    }
}
