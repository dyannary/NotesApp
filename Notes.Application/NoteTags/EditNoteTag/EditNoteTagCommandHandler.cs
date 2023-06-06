using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces.Messaging;
using Notes.Persistence.Context;

namespace Notes.Application.NoteTags.EditNoteTag;

public class EditNoteTagCommandHandler : ICommandHandler<EditNoteTagCommand, int?>
{
    private readonly NotesDbContext _notesDbContext;
    private readonly IMapper _mapper;
        
    public EditNoteTagCommandHandler(NotesDbContext notesDbContext, IMapper mapper)
    {
        _notesDbContext = notesDbContext;
        _mapper = mapper;
    }

    public async Task<int?> Handle(EditNoteTagCommand request, CancellationToken cancellationToken)
    {
        var tagEntity = await _notesDbContext.NoteTags.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken: cancellationToken);

        if (tagEntity is null)
        {
            return null;
        }

        _mapper.Map(request.Data, tagEntity);
        await _notesDbContext.SaveChangesAsync(cancellationToken);

        return tagEntity.Id;
    }
}