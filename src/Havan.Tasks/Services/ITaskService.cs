using Havan.Tasks.Domain.Entities;
using Havan.Tasks.Domain.Enums;

namespace Havan.Tasks.Services;

public interface ITaskService
{
    TaskItem Create(
        string title,
        string description
    );

    TaskItem UpdateStatus(
        Guid id,
        TodoTaskStatus status
    );

    IEnumerable<TaskItem> GetActiveTasks();

    IEnumerable<TaskItem> GetCompletedTasks(
        DateTime startDate,
        DateTime endDate
    );
}