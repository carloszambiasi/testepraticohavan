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
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException(
                "O título é obrigatório."
            );
        }

        if (title.Trim().Length < 5)
        {
            throw new ArgumentException(
                "O título deve possuir pelo menos 5 caracteres."
            );
        }

        Id = Guid.NewGuid();

        Title = title.Trim();

        Description = description?.Trim() ?? string.Empty;

        CreatedAt = DateTime.UtcNow;

        Status = TodoTaskStatus.Pendente;
    }

    public void UpdateStatus(TodoTaskStatus newStatus)
    {
        if (Status == TodoTaskStatus.Concluida)
        {
            throw new InvalidOperationException(
                "Não é possível alterar uma tarefa já concluída."
            );
        }

        Status = newStatus;

        if (newStatus == TodoTaskStatus.Concluida)
        {
            CompletedAt = DateTime.UtcNow;
        }
    }
}