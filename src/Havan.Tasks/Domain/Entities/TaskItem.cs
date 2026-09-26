using Havan.Tasks.Domain.Enums;

namespace Havan.Tasks.Domain.Entities;

public class TaskItem
{
    public Guid Id { get; private set; }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? CompletedAt { get; private set; }

    public TodoTaskStatus Status { get; private set; }

    public TaskItem(string title, string description)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        CreatedAt = DateTime.UtcNow;
        Status = TodoTaskStatus.Pendente;
    }
}