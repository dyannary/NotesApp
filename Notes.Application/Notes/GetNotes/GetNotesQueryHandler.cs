using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces.Messaging;
using Notes.DataTransferObjects.Notes;
using Notes.Persistence.Context;

namespace Notes.Application.Notes.GetNotes;

internal class GetNotesQueryHandler : IQueryHandler<GetNotesQuery, List<NoteDto>>
{
    private readonly NotesDbContext _notesDbContext;
    private readonly IMapper _mapper;

    public GetNotesQueryHandler(NotesDbContext notesDbContext, IMapper mapper)
    {
        _notesDbContext = notesDbContext;
        _mapper = mapper;
    }

    public async Task<List<NoteDto>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
    {
        var products = await _notesDbContext.Notes.ToListAsync(cancellationToken: cancellationToken);

        return _mapper.Map<List<NoteDto>>(products);
    }
}