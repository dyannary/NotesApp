using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.DeleteNote;
using Notes.Application.Notes.EditNote;
using Notes.Application.Notes.GetNote;
using Notes.Application.Tasks.AddTask;
using Notes.Application.Tasks.DeleteTask;
using Notes.Application.Tasks.EditTask;
using Notes.Application.Tasks.GetTask;
using Notes.Application.Tasks.GetTasks;
using Notes.DataTransferObjects.Notes;
using Notes.DataTransferObjects.Tasks;

namespace Notes.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<TaskDto> GetTask(int id)
    {
        var query = new GetTaskQuery { Id = id };
        return await _mediator.Send(query);
    }

    [HttpGet]
    public async Task<List<TaskDto>> GetTasks()
    {
        return await _mediator.Send(new GetTasksQuery());
    }

    [HttpPut]
    public async Task<int> EditTask([FromBody] EditTaskCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPost]
    public async Task<int> CreateTask([FromBody] AddTaskCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<Unit> DeleteTask([FromRoute] int id)
    {
        var command = new DeleteTaskCommand { Id = id };
        return await _mediator.Send(command);
    }
}
