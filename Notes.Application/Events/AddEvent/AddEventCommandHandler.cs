using AutoMapper;
using Notes.Application.FactoryMethod;
using Notes.Application.Interfaces.Messaging;
using Notes.Domain;
using Notes.Persistence.Context;

namespace Notes.Application.Events.AddEvent;

public class AddEventCommandHandler : ICommandHandler<AddEventCommand, int>
{
    private readonly NotesDbContext _noteDbContext;

    public AddEventCommandHandler(NotesDbContext noteDbContext)
    {
        _noteDbContext = noteDbContext;
    }

    public async Task<int> Handle(AddEventCommand request, CancellationToken cancellationToken)
    {
        INoteFactory eventFactory = new EventFactory(request.Data);


        var eventToCreate = (Event)eventFactory.Create();

        await _noteDbContext.Events.AddAsync(eventToCreate, cancellationToken);
        await _noteDbContext.SaveChangesAsync(cancellationToken);

        return eventToCreate.Id;
    }
}