using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces.Messaging;
using Notes.DataTransferObjects.Events;
using Notes.Persistence.Context;

namespace Notes.Application.Events.GetEvents;

public class GetEventsQueryHandler : IQueryHandler<GetEventsQuery, List<EventDto>>
{
    private readonly NotesDbContext _notesDbContext;
    private readonly IMapper _mapper;

    public GetEventsQueryHandler(NotesDbContext notesDbContext, IMapper mapper)
    {
        _notesDbContext = notesDbContext;
        _mapper = mapper;
    }

    public async Task<List<EventDto>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _notesDbContext.Events.ToListAsync(cancellationToken: cancellationToken);

        return _mapper.Map<List<EventDto>>(tasks);
    }
}
