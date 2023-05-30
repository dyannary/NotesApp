using AutoMapper;
using MediatR;
using Notes.Domain;
using Notes.Persistence.Context;

namespace Notes.Application.Events.AddEvent;

public class AddEventCommandHandler : IRequestHandler<AddEventCommand, int>
{
    private readonly NotesDbContext _noteDbContext;
    private readonly IMapper _mapper;

    public AddEventCommandHandler(NotesDbContext noteDbContext, IMapper mapper)
    {
        _noteDbContext = noteDbContext;
        _mapper = mapper;
    }

    public async Task<int> Handle(AddEventCommand request, CancellationToken cancellationToken)
    {
        var eventToCreate = _mapper.Map<Event>(request.Data);

        await _noteDbContext.Events.AddAsync(eventToCreate);
        await _noteDbContext.SaveChangesAsync();

        return eventToCreate.Id;
    }
}