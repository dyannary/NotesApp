using Notes.DataTransferObjects.Notes;
using Notes.Domain;

namespace Notes.Application.FactoryMethod;

internal class NoteFactory: INoteFactory
{
    public NoteFactory(AddEditNoteDto noteToCreate)
    {
        _noteToCreate = noteToCreate;
    }

    private readonly AddEditNoteDto _noteToCreate;

    public Entity Create()
    {
        var noteTags = new List<NoteTag>();

        foreach (var noteTag in _noteToCreate.NoteTags)
        {
            var tag = new NoteTag
            {
                Title = noteTag.Title,
                Color = noteTag.Color,
                CreatedDate = DateTime.Now
            };
            noteTags.Add(tag);
        }

        Entity note = new Note
        {
            Title = _noteToCreate.Title,
            Content = _noteToCreate.Content,
            CreatedDate = DateTime.Now,
            Color = string.IsNullOrEmpty(_noteToCreate.Color) ? "c5c5db" : _noteToCreate.Color,
            NoteTags = noteTags
        };

        return note;
    }
}