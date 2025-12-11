using CleanArch.Application.Dtos.TodoItems;
using CleanArch.Application.Interfaces;
using MediatR;

namespace CleanArch.Application.Features.TodoItems.Commands.UpdateTodoItem;

public class UpdateTodoItemCommandHandler
    : IRequestHandler<UpdateTodoItemCommand, TodoItemDto?>
{
    private readonly ITodoItemRepository _repository;

    public UpdateTodoItemCommandHandler(ITodoItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<TodoItemDto?> Handle(
        UpdateTodoItemCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
        {
            return null;
        }

        entity.Title = request.Title;
        entity.Description = request.Description;
        entity.IsCompleted = request.IsCompleted;

        await _repository.UpdateAsync(entity, cancellationToken);

        return entity.ToDto();
    }
}
