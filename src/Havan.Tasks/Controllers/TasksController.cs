using Havan.Tasks.DTOs;
using Havan.Tasks.Services;
using Microsoft.AspNetCore.Mvc;

namespace Havan.Tasks.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _service;

    public TasksController(ITaskService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Create(
        CreateTaskRequest request
    )
    {
        try
        {
            var task = _service.Create(
                request.Title,
                request.Description
            );

            return StatusCode(
                StatusCodes.Status201Created,
                task
            );
        }
        catch (ArgumentException exception)
        {
            return BadRequest(new
            {
                message = exception.Message
            });
        }
    }

    [HttpGet("active")]
    public IActionResult GetActive()
    {
        var tasks = _service.GetActiveTasks();

        return Ok(tasks);
    }

    [HttpGet("completed")]
    public IActionResult GetCompleted(
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate
    )
    {
        try
        {
            var tasks = _service.GetCompletedTasks(
                startDate,
                endDate
            );

            return Ok(tasks);
        }
        catch (ArgumentException exception)
        {
            return BadRequest(new
            {
                message = exception.Message
            });
        }
    }

    [HttpPatch("{id:guid}/status")]
    public IActionResult UpdateStatus(
        Guid id,
        UpdateTaskStatusRequest request
    )
    {
        try
        {
            var task = _service.UpdateStatus(
                id,
                request.Status
            );

            return Ok(task);
        }
        catch (KeyNotFoundException exception)
        {
            return NotFound(new
            {
                message = exception.Message
            });
        }
        catch (InvalidOperationException exception)
        {
            return BadRequest(new
            {
                message = exception.Message
            });
        }
    }
}