using CleanArch.Application.Dtos.TodoItems;
using MediatR;

namespace CleanArch.Application.Features.TodoItems.Queries.GetTodoItemById;

public record GetTodoItemByIdQuery(int Id) : IRequest<TodoItemDto?>;
