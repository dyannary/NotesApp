using Notes.Application.Interfaces.Messaging;
using Notes.DataTransferObjects.Notes;

namespace Notes.Application.Notes.GetNotes;

public record GetEventsQuery : IQuery<List<NoteDto>>;