using Notes.DataTransferObjects.Notes;

namespace Notes.Blazor.Services.Interfaces;

public interface INoteService
{
    Task<IEnumerable<NoteDto>> GetNotesAsync();
    Task<NoteDto> GetNoteByIdAsync(int id);

    Task<int> AddNoteAsync(AddEditNoteDto note);
}