namespace CleanArch.Domain.Entities;

public class TodoItem
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }

    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Many-to-many relation with Tag
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
