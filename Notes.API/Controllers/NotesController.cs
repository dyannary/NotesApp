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
    public async Task<NoteDto> GetNote(int id)
    {
        var query = new GetNoteQuery { Id = id };
        return await _mediator.Send(query);
    }

    [HttpGet]
    public async Task<List<NoteDto>> GetNotes()
    {
        return await _mediator.Send(new GetNotesQuery());
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