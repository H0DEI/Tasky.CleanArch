using System.Collections.Generic;
using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Persistence;

public class CleanArchDbContext : DbContext
{
    public CleanArchDbContext(DbContextOptions<CleanArchDbContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    public DbSet<Tag> Tags => Set<Tag>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureTodoItem(modelBuilder);
        ConfigureTag(modelBuilder);
        ConfigureTodoItemTagRelation(modelBuilder);
    }

    private static void ConfigureTodoItem(ModelBuilder modelBuilder)
    {
        var entity = modelBuilder.Entity<TodoItem>();

        entity.ToTable("TodoItems");

        entity.HasKey(t => t.Id);

        entity.Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(200);

        entity.Property(t => t.Description)
            .HasMaxLength(1000);
    }

    private static void ConfigureTag(ModelBuilder modelBuilder)
    {
        var entity = modelBuilder.Entity<Tag>();

        entity.ToTable("Tags");

        entity.HasKey(t => t.Id);

        entity.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);
    }

    private static void ConfigureTodoItemTagRelation(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>()
            .HasMany(t => t.Tags)
            .WithMany(t => t.TodoItems)
            .UsingEntity<Dictionary<string, object>>(
                "TodoItemTag",
                j => j
                    .HasOne<Tag>()
                    .WithMany()
                    .HasForeignKey("TagId")
                    .HasConstraintName("FK_TodoItemTag_Tag_TagId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<TodoItem>()
                    .WithMany()
                    .HasForeignKey("TodoItemId")
                    .HasConstraintName("FK_TodoItemTag_TodoItem_TodoItemId")
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.ToTable("TodoItemTags");
                    j.HasKey("TodoItemId", "TagId");
                });
    }
}
