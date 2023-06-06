using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.DeleteNote;
using Notes.Application.Notes.EditNote;
using Notes.Application.NoteTags.AddNoteTag;
using Notes.Application.NoteTags.DeleteNoteTag;
using Notes.Application.NoteTags.EditNoteTag;
using Notes.Application.NoteTags.GetTags;
using Notes.DataTransferObjects.Notes;
using Notes.DataTransferObjects.NoteTags;

namespace Notes.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NoteTagsController : ControllerBase
{
    private readonly IMediator _mediator;

    public NoteTagsController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<NoteTagDto>>> GetTags([FromQuery] int noteId)
    {
        var noteTags = await _mediator.Send(new GetNoteTagsQuery(noteId));

        if (!noteTags.Any())
        {
            return NoContent();
        }

        return Ok(noteTags);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<NoteTagDto>>> GetTag([FromRoute] int id)
    {

        return Ok();
    }

    [HttpPost]  
    public async Task<ActionResult> CreateNoteTag([FromBody] NoteTagDto noteTagToAdd)
    {
        var result = await _mediator.Send(new AddNoteTagCommand(noteTagToAdd));

        return Ok(result);
    }


    [HttpPut]   
    public async Task<ActionResult> EditNoteTag([FromBody] NoteTagDto noteTagToAdd)
    {
        var result = await _mediator.Send(new EditNoteTagCommand(noteTagToAdd));

        if (result is null)
        {
            return NotFound($"Note with this Id is not found");
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteNote([FromRoute] int id)
    {
        var command = new DeleteNoteTagCommand(id);
        var result = await _mediator.Send(command);

        if (result is null)
        {
            return NotFound("NoteTag with not found");
        }

        return Ok(result);
    }
}