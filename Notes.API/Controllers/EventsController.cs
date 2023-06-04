using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Events.AddEvent;
using Notes.Application.Events.DeleteEvent;
using Notes.Application.Events.EditEvent;
using Notes.Application.Events.GetEvent;
using Notes.Application.Events.GetEvents;
using Notes.DataTransferObjects.Events;

namespace Notes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetEvent([FromRoute] int id)
        {
            var query = new GetEventQuery { Id = id };
            var result = await _mediator.Send(query);

            if(result is null)
            {
                return NotFound($"Event with Id {id} is not found!");
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEvents()
        {
            var result = await _mediator.Send(new GetEventsQuery());

            if(!result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEvent([FromBody] AddEditEventDto eventToAdd)
        {
            var result = await _mediator.Send(new AddEventCommand(eventToAdd));

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> EditEvent([FromBody] EditEventCommand command)
        {
            var result = await _mediator.Send(command);

            if( result is null )
            {
                return NotFound($"Event with this Id is not found!");
            }

            return Ok(result);
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateEvent([FromBody] EditEventCommand command)
        {
            var result = await _mediator.Send(command);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent([FromRoute] int id)
        {
            var command = new DeleteEventCommand { Id = id };
            var result = await _mediator.Send(command);

            if (result is null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }

            return Ok(result);
        }
    }
}
