using CleanArch.Application.Dtos.TodoItems;
using CleanArch.Application.Interfaces;
using MediatR;

namespace CleanArch.Application.Features.TodoItems.Queries.GetTodoItemById;

public class GetTodoItemByIdQueryHandler
    : IRequestHandler<GetTodoItemByIdQuery, TodoItemDto?>
{
    private readonly ITodoItemRepository _repository;

    public GetTodoItemByIdQueryHandler(ITodoItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<TodoItemDto?> Handle(
        GetTodoItemByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);

        return entity?.ToDto(); // devuelve null si no existe
    }
}
