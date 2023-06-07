using Notes.DataTransferObjects.Notes;
using Notes.DataTransferObjects.NoteTags;
namespace Notes.Blazor.Builder;

public interface INoteBuilder
{
    AddEditNoteDto Build();
}