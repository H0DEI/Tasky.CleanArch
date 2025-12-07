using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Repositories;

public class TodoItemRepository : ITodoItemRepository
{
    private readonly CleanArchDbContext _dbContext;

    public TodoItemRepository(CleanArchDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TodoItem?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.TodoItems
            .Include(t => t.Tags)
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    public async Task<List<TodoItem>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.TodoItems
            .Include(t => t.Tags)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(TodoItem item, CancellationToken cancellationToken = default)
    {
        await _dbContext.TodoItems.AddAsync(item, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(TodoItem item, CancellationToken cancellationToken = default)
    {
        _dbContext.TodoItems.Update(item);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(TodoItem item, CancellationToken cancellationToken = default)
    {
        _dbContext.TodoItems.Remove(item);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.TodoItems.AnyAsync(t => t.Id == id, cancellationToken);
    }
}
