using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.AddNote;
using Notes.Application.Notes.GetNotes;
using Notes.DataTransferObjects.Notes;

namespace Notes.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotesController : ControllerBase
{
    private readonly IMediator _mediator;

    public NotesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<NoteDto>> GetProducts()
    {
        return await _mediator.Send(new GetNotesQuery());
    }

    [HttpPost]
    public async Task<int> CreateNote([FromBody] AddNoteCommand command)
    {
        return await _mediator.Send(command);
    }
}