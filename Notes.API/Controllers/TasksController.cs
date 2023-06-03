using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Tasks.AddTask;
using Notes.Application.Tasks.DeleteTask;
using Notes.Application.Tasks.EditTask;
using Notes.Application.Tasks.GetTask;
using Notes.Application.Tasks.GetTasks;
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
    public async Task<ActionResult<TaskDto?>> GetTask(int id)
    {
        var query = new GetTaskQuery { Id = id };
        var task = await _mediator.Send(query);

        if(task is null)
        {
            return BadRequest($"Note with id: {id} not found");
        }

        return Ok(task);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskDto?>>> GetTasks()
    {
        var tasks = await _mediator.Send(new GetTasksQuery());

        if (!tasks.Any())
        {
            return NotFound();
        }

        return Ok(tasks);
    }

    [HttpPost]
    public async Task<int> CreateTask([FromBody] AddTaskCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut]
    public async Task<ActionResult> EditTask([FromBody] EditTaskCommand command)
    {
        var result = await _mediator.Send(command);

        if (result is null)
        {
            return NotFound($"Employee with this Id is not found");
        }

        return Ok(result);
    }

    [HttpPatch]
    public async Task<ActionResult> UpdateTask([FromBody] EditTaskCommand command)
    {
        var result = await _mediator.Send(command);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTask([FromRoute] int id)
    {
        var command = new DeleteTaskCommand { Id = id };
        var result = await _mediator.Send(command);

        if (result is null)
        {
            return NotFound($"Employee with Id = {id} not found");
        }

        return Ok(result);
    }
}
