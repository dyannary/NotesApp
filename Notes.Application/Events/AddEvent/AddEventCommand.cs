using MediatR;
using Notes.DataTransferObjects.Events;

namespace Notes.Application.Events.AddEvent;

public class AddEventCommand : IRequest<int>
{
    public AddEditEventDto Data { get; set; }
}
