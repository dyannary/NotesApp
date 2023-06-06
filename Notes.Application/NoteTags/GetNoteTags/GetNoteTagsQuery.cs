using MediatR;
using Notes.DataTransferObjects.NoteTags;

namespace Notes.Application.NoteTags.GetTags;

public class GetNoteTagsQuery : IRequest<IEnumerable<NoteTagDto>>
{
    public int NoteId { get; set; }

    public GetNoteTagsQuery(int noteId)
    {
        NoteId = noteId;
    }
}