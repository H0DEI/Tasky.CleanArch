using CleanArch.Application.Dtos.TodoItems;
using MediatR;

namespace CleanArch.Application.Features.TodoItems.Commands.UpdateTodoItem;

public record UpdateTodoItemCommand(
    int Id,
    string Title,
    string? Description,
    bool IsCompleted
) : IRequest<TodoItemDto?>;
