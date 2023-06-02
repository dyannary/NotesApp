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
        public async Task<EventDto> GetEvent([FromRoute] int id)
        {
            var query = new GetEventQuery { Id = id };
            return await _mediator.Send(query);
        }

        [HttpGet]
        public async Task<List<EventDto>> GetEvents()
        {
            return await _mediator.Send(new GetEventsQuery());
        }

        [HttpPost]
        public async Task<int> CreateEvent([FromBody] AddEventCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        public async Task<int> EditEvent([FromBody] EditEventCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<Unit> DeleteEvent([FromRoute] int id)
        {
            var command = new DeleteEventCommand { Id = id };
            return await _mediator.Send(command);
        }
    }
}
