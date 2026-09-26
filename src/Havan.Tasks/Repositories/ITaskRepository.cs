using Havan.Tasks.Domain.Entities;

namespace Havan.Tasks.Repositories;

public interface ITaskRepository
{
    void Add(TaskItem task);

    TaskItem? GetById(Guid id);

    IEnumerable<TaskItem> GetAll();
}