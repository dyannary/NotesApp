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
        Entity note = new Note
        {
            Title = _noteToCreate.Title,
            Content = _noteToCreate.Content
        };

        return note;
    }
}