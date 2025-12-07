namespace CleanArch.Domain.Entities;

public class Tag
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    // Many-to-many relation with TodoItem
    public ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
}
