using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Notes.AddNote;
using Notes.Application.Notes.GetProducts;
using Notes.Data.Persistence.Context;
using Notes.DataTransferObjects.Notes;
using Notes.Persistence.Entities;

namespace Notes.API.Controllers
{
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
            return await _mediator.Send(new GetProductsQuery());
        }

        [HttpPost]
        public async Task<int> CreateNote([FromBody] AddNoteCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}