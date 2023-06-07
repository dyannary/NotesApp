using Notes.Persistence.Context;
using System.Net;
using Notes.DataTransferObjects.Notes;
using Notes.Domain;

namespace Notes.Application.Notes;

public static class GetAndFilterNotes
{
    public static IQueryable<Note> Filter(NotesDbContext notesDbContext, string title)
    {
        var notes = notesDbContext.Notes
            .OrderByDescending(x=>x.CreatedDate)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(title))
        {
            notes = notes.Where(x => x.Title.ToLower().Contains(title.ToLower()));
        }

        return notes;
    }
}