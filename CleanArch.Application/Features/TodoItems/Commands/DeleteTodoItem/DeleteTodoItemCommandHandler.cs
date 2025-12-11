using CleanArch.Application.Interfaces;
using MediatR;

namespace CleanArch.Application.Features.TodoItems.Commands.DeleteTodoItem;

public class DeleteTodoItemCommandHandler
    : IRequestHandler<DeleteTodoItemCommand, bool>
{
    private readonly ITodoItemRepository _repository;

    public DeleteTodoItemCommandHandler(ITodoItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteTodoItemCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
        {
            return false;
        }

        await _repository.DeleteAsync(entity, cancellationToken);
        return true;
    }
}
