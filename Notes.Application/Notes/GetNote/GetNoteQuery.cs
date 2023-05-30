using MediatR;
using Notes.DataTransferObjects.Notes;

namespace Notes.Application.Notes.GetNote;

public class GetNoteQuery : IRequest<NoteDto>
{
    public int Id { get; set; }
}
