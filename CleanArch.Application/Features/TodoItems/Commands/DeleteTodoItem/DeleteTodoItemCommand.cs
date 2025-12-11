using MediatR;

namespace CleanArch.Application.Features.TodoItems.Commands.DeleteTodoItem;

public record DeleteTodoItemCommand(int Id) : IRequest<bool>;
