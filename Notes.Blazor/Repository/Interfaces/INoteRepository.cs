using Notes.DataTransferObjects.Notes;

namespace Notes.Blazor.Services.Interfaces;

public interface INoteRepository
{
    Task<IEnumerable<NoteDto>> GetNotesAsync();
    Task<NoteDto> GetNoteByIdAsync(int id);
    Task<int> AddNoteAsync(AddEditNoteDto note);
    Task DeleteNoteAsync(int id);
    Task UpdateNoteAsync(AddEditNoteDto note);
}