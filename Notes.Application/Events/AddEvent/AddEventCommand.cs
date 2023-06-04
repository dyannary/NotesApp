using Notes.Application.Interfaces.Messaging;
using Notes.DataTransferObjects.Events;

namespace Notes.Application.Events.AddEvent;

public class AddEventCommand : ICommand<int>
{
    public AddEventCommand(AddEditEventDto data)
    {
        Data = data;
    }

    public AddEditEventDto Data { get; private set; }
}
