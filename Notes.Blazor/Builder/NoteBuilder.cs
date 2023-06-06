using Notes.DataTransferObjects.Notes;
using Notes.DataTransferObjects.NoteTags;

namespace Notes.Blazor.Builder;

public class NoteBuilder
{
    private AddEditNoteDto _note = new();

    public NoteBuilder()
    {
        Reset();
    }

    public void Reset()
    {
        _note = new AddEditNoteDto();
    }

    public NoteBuilder AddTitle(string title)
    {
        _note.Title = title;
        return this;
    }

    public NoteBuilder AddContent(string content)
    {
        _note.Content = content;
        return this;
    }

    public NoteBuilder RemoveContent()
    {
        _note.Content = string.Empty;
        return this;
    }

    public NoteBuilder AddBorderColor(string color)
    {
        _note.Color = color;
        return this;
    }
        
    public NoteBuilder RemoveBorderColor()
    {
        _note.Color = "#27272f";
        return this;
    }

    public NoteBuilder AddTag(NoteTagDto noteTag)
    {
        _note.NoteTags.Add(noteTag);
        return this;
    }


    public AddEditNoteDto Build()
    {
        var note = _note.Clone();
        Reset();
        return note;
    }
}