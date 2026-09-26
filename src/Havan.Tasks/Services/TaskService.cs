using Havan.Tasks.Domain.Entities;
using Havan.Tasks.Domain.Enums;
using Havan.Tasks.Repositories;

namespace Havan.Tasks.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;

    public TaskService(ITaskRepository repository)
    {
        _repository = repository;
    }

    public TaskItem Create(
        string title,
        string description
    )
    {
        var task = new TaskItem(
            title,
            description
        );

        _repository.Add(task);

        return task;
    }

    public TaskItem UpdateStatus(
        Guid id,
        TodoTaskStatus status
    )
    {
        var task = _repository.GetById(id);

        if (task is null)
        {
            throw new KeyNotFoundException(
                "Tarefa não encontrada."
            );
        }

        task.UpdateStatus(status);

        return task;
    }

    public IEnumerable<TaskItem> GetActiveTasks()
    {
        return _repository
            .GetAll()
            .Where(task =>
                task.Status == TodoTaskStatus.Pendente ||
                task.Status == TodoTaskStatus.EmAndamento
            );
    }

    public IEnumerable<TaskItem> GetCompletedTasks(
        DateTime startDate,
        DateTime endDate
    )
    {
        if (startDate > endDate)
        {
            throw new ArgumentException(
                "A data inicial não pode ser maior que a data final."
            );
        }

        return _repository
            .GetAll()
            .Where(task =>
                task.Status == TodoTaskStatus.Concluida &&
                task.CompletedAt.HasValue &&
                task.CompletedAt.Value >= startDate &&
                task.CompletedAt.Value <= endDate
            );
    }
}