using Microsoft.AspNetCore.Mvc;

using MediatR;

using CleanArch.Application.Dtos.TodoItems;
using CleanArch.Application.Features.TodoItems.Queries.GetTodoItems;
using CleanArch.Application.Features.TodoItems.Queries.GetTodoItemById;
using CleanArch.Application.Features.TodoItems.Commands.CreateTodoItem;
using CleanArch.Application.Features.TodoItems.Commands.UpdateTodoItem;
using CleanArch.Application.Features.TodoItems.Commands.DeleteTodoItem;

namespace CleanArch.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/todoitems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetTodoItemsQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TodoItemDto>> GetById(
    int id,
    CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetTodoItemByIdQuery(id), cancellationToken);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    // POST: api/todoitems
    [HttpPost]
    public async Task<ActionResult<TodoItemDto>> Create(
        [FromBody] CreateTodoItemRequest request,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new CreateTodoItemCommand(request.Title, request.Description);
        var dto = await _mediator.Send(command, cancellationToken);

        return CreatedAtAction(
            nameof(GetAll), // provisional, luego cambiaremos a GetById cuando lo tengamos
            new { id = dto.Id },
            dto);
    }

    // PUT: api/todoitems/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] UpdateTodoItemRequest request,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new UpdateTodoItemCommand(
            id,
            request.Title,
            request.Description,
            request.IsCompleted);

        var result = await _mediator.Send(command, cancellationToken);

        if (result is null)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/todoitems/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(
        int id,
        CancellationToken cancellationToken)
    {
        var command = new DeleteTodoItemCommand(id);
        var deleted = await _mediator.Send(command, cancellationToken);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }

}
