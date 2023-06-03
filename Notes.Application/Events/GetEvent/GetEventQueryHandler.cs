using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.DataTransferObjects.Events;
using Notes.Persistence.Context;

namespace Notes.Application.Events.GetEvent;

public class GetEventQueryHandler : IRequestHandler<GetEventQuery, EventDto?>
{
    private readonly NotesDbContext _noteDbContext;
    private readonly IMapper _mapper;

    public GetEventQueryHandler(NotesDbContext appDbContext, IMapper mapper)
    {
        _noteDbContext = appDbContext;
        _mapper = mapper;
    }

    public async Task<EventDto?> Handle(GetEventQuery request, CancellationToken cancellationToken)
    {
        var _event = await _noteDbContext.Events.FirstOrDefaultAsync(x => x.Id == request.Id);

        if(_event is null)
        {
            return null;
        }

        return _mapper.Map<EventDto>(_event);
    }
}
