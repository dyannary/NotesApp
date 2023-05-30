using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces.Messaging;
using Notes.DataTransferObjects.Notes;
using Notes.Persistence.Context;

namespace Notes.Application.Notes.GetNotes;

public class GetNotesQueryHandler : IQueryHandler<GetEventsQuery, List<NoteDto>>
{
    private readonly NotesDbContext _notesDbContext;
    private readonly IMapper _mapper;

    public GetNotesQueryHandler(NotesDbContext notesDbContext, IMapper mapper)
    {
        _notesDbContext = notesDbContext;
        _mapper = mapper;
    }

    public async Task<List<NoteDto>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
    {
        var notes = await _notesDbContext.Notes.ToListAsync(cancellationToken: cancellationToken);

        return _mapper.Map<List<NoteDto>>(notes);
    }
}