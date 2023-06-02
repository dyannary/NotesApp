using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.DataTransferObjects.Notes;
using Notes.Persistence.Context;
namespace Notes.Application.Notes.GetNote;

public class GetNoteQueryHandler : IRequestHandler<GetNoteQuery, NoteDto?>
{
    private readonly NotesDbContext _notesDbContext;
    private readonly IMapper _mapper;

    public GetNoteQueryHandler(NotesDbContext notesDbContext, IMapper mapper)
    {
        _notesDbContext = notesDbContext;
        _mapper = mapper;   
    }
    public async Task<NoteDto?> Handle(GetNoteQuery request, CancellationToken cancellationToken)
    {
        var plan = await _notesDbContext.Notes
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        return _mapper.Map<NoteDto>(plan);
    }
}
