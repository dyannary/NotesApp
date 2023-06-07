using Microsoft.AspNetCore.Components;
using MudBlazor;
using Notes.Blazor.Memento;
using Notes.Blazor.Services.Implementations;
using Notes.Blazor.Services.Interfaces;
using Notes.DataTransferObjects.Events;

namespace Notes.Blazor.Pages.EventPages
{
    public partial class EventsDetailsReadOnly
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IEventService EventService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public DateStateService dateStateService { get; set; }

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
                var @event = await EventService.GetEventByIdAsync(Id);

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
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }
        private async Task GoToEventPage()
        {
            NavigationManager.NavigateTo("events");
        }
        public async Task Cancel()
        {
            NavigationManager.NavigateTo($"events");
        }

    }
}
