using MediatR;
using Notes.DataTransferObjects.Events;

namespace Notes.Application.Events.EditEvent;

public class EditEventCommand : IRequest<int>
{
    public AddEditEventDto Data { get; set; }
}
