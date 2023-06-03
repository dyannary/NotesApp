using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Persistence.Context;

namespace Notes.Application.Notes.EditNote;

public class EditNoteCommandHandler : IRequestHandler<EditNoteCommand, int?>
{
    private readonly NotesDbContext _notesDbContext;
    private readonly IMapper _mapper;

    public EditNoteCommandHandler(NotesDbContext notesDbContext, IMapper mapper)
    {
        _notesDbContext = notesDbContext;
        _mapper = mapper;
    }
    public async Task<int?> Handle(EditNoteCommand request, CancellationToken cancellationToken)
    {
        var noteToEdit = await _notesDbContext.Notes.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken: cancellationToken);

        if (noteToEdit is null)
        {
            return null;
        }

        _mapper.Map(request.Data, noteToEdit);
        await _notesDbContext.SaveChangesAsync(cancellationToken);
       
        return noteToEdit.Id;
    }
}
