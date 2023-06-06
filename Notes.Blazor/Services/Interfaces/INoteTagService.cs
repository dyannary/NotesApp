using Notes.DataTransferObjects.NoteTags;

namespace Notes.Blazor.Services.Interfaces;

public interface INoteTagService    
{
    Task<IEnumerable<NoteTagDto>> GetNoteTagsAsync(int noteId);
    Task<int> AddNoteTagAsync(NoteTagDto noteTag);
    Task DeleteNoteTagAsync(int id);
    Task UpdateNoteTagAsync(NoteTagDto noteTag);
}   