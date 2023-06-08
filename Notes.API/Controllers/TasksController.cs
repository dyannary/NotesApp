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
            return BadRequest($"Task not found");
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
    public async Task<ActionResult> CreateTask([FromBody] AddEditTaskDto taskToAdd)
    {
        var result = await _mediator.Send(new AddTaskCommand(taskToAdd));

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult> EditTask([FromBody] TaskDto taskToEdit)
    {
        var result = await _mediator.Send(new EditTaskCommand(taskToEdit));

        if (result is null)
        {
            return NotFound($"Task not found");
        }

        return Ok(result);
    }

    [HttpPatch]
    public async Task<ActionResult> UpdateTask([FromBody] TaskDto taskToEdit)
    {
        var result = await _mediator.Send(new EditTaskCommand(taskToEdit));

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
            return NotFound("Task not found");
        }

        return Ok(result);
    }
}
