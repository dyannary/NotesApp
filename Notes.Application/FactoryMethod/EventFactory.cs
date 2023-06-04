using Notes.DataTransferObjects.Events;
using Notes.Domain;

namespace Notes.Application.FactoryMethod;

internal class EventFactory: INoteFactory
{
    public EventFactory(AddEditEventDto eventToCreate)
    {
        _eventToCreate = eventToCreate;
    }

    private readonly AddEditEventDto _eventToCreate;


    public Entity Create()
    {
        Entity note = new Event
        {
            Name = _eventToCreate.Name,
            Description = _eventToCreate.Description,
            StartDate = _eventToCreate.StartDate,
            EndDate = _eventToCreate.EndDate,
            AllDay = _eventToCreate.AllDay,
        };

        return note;
    }
}