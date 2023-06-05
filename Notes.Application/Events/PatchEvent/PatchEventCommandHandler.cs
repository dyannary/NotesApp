using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Events.EditEvent;
using Notes.DataTransferObjects.Events;
using Notes.Persistence.Context;

namespace Notes.Application.Events.PatchEvent;

public class PatchEventCommandHandler : IRequestHandler<PatchEventCommand, int?>
{
    private readonly NotesDbContext _noteDbContext;
    private readonly IMapper _mapper;

    public PatchEventCommandHandler(NotesDbContext noteDbContext, IMapper mapper)
    {
        _noteDbContext = noteDbContext;
        _mapper = mapper;
    }

    public async Task<int?> Handle(PatchEventCommand request, CancellationToken cancellationToken)
    {
        var editEvent = await _noteDbContext.Events.FirstOrDefaultAsync(x => x.Id == request.EventId);

        if (editEvent is null)
        {
            return null;
        }

        var eventDto = new AddEditEventDto();
        
        _mapper.Map(editEvent, eventDto);

        request.PatchDoc.ApplyTo(eventDto);

        _mapper.Map(eventDto, editEvent);

        await _noteDbContext.SaveChangesAsync();

        return editEvent.Id;
    }
}