using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.AddNote;
using Notes.Application.Notes.DeleteNote;
using Notes.Application.Notes.EditNote;
using Notes.Application.Notes.GetNote;
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

    [HttpGet("{id}")]
    public async Task<ActionResult<NoteDto>> GetNote(int id)
    {
        var query = new GetNoteQuery { Id = id };
        var note = await _mediator.Send(query);

        if (note is null)
        {
            return BadRequest($"Note with id: {id} not found");
        }

        return Ok(note);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NoteDto>>> GetNotes()
    {
        var notes = await _mediator.Send(new GetNotesQuery());

        if (!notes.Any())
        {
            return NotFound();
        }

        return Ok(notes);
    }

    [HttpPost]
    public async Task<int> CreateNote([FromBody] AddNoteCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut]
    public async Task<int> EditNote([FromBody] EditNoteCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<Unit> DeleteNote([FromRoute] int id)
    {
        var command = new DeleteNoteCommand { Id = id };
        return await _mediator.Send(command);
    }
}