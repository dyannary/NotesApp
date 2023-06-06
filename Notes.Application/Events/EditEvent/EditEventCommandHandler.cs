using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Persistence.Context;

namespace Notes.Application.Events.EditEvent;

public class EditEventCommandHandler : IRequestHandler<EditEventCommand, int?>
{
    private readonly NotesDbContext _noteDbContext;
    private readonly IMapper _mapper;

    public EditEventCommandHandler(NotesDbContext noteDbContext, IMapper mapper)
    {
        _noteDbContext = noteDbContext;
        _mapper = mapper;
    }

    public async Task<int?> Handle(EditEventCommand request, CancellationToken cancellationToken)
    {
        var editEvent = await _noteDbContext.Events.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken: cancellationToken);

        if(editEvent is null)
        {
            return null;    
        }

        _mapper.Map(request.Data, editEvent);
        await _noteDbContext.SaveChangesAsync(cancellationToken);

        return editEvent.Id;
    }
}