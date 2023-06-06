using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.DataTransferObjects.NoteTags;
using Notes.Persistence.Context;

namespace Notes.Application.NoteTags.GetTags;

public class GetNoteTagsQueryHandler : IRequestHandler<GetNoteTagsQuery, IEnumerable<NoteTagDto>>
{
    private readonly NotesDbContext _notesDbContext;
    private readonly IMapper _mapper;

    public GetNoteTagsQueryHandler(NotesDbContext notesDbContext, IMapper mapper)
    {
        _notesDbContext = notesDbContext;
        _mapper = mapper;
    }
    public async Task<IEnumerable<NoteTagDto>> Handle(GetNoteTagsQuery request, CancellationToken cancellationToken)
    {
        var noteTags = await _notesDbContext.NoteTags
            .Where(x => x.NoteId == request.NoteId).ToListAsync(cancellationToken);

        return _mapper.Map<List<NoteTagDto>>(noteTags);
    }
}