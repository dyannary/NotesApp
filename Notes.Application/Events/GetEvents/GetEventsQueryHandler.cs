using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces.Messaging;
using Notes.DataTransferObjects.Events;
using Notes.Persistence.Context;

namespace Notes.Application.Events.GetEvents;

public class GetEventsQueryHandler : IQueryHandler<GetEventsQuery, IEnumerable<EventDto>>
{
    private readonly NotesDbContext _notesDbContext;
    private readonly IMapper _mapper;

    public GetEventsQueryHandler(NotesDbContext notesDbContext, IMapper mapper)
    {
        _notesDbContext = notesDbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EventDto>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _notesDbContext.Events.ToListAsync(cancellationToken: cancellationToken);

        return _mapper.Map<List<EventDto>>(tasks);
    }
}
