using Havan.Tasks.Domain.Entities;

namespace Havan.Tasks.Repositories;

public class InMemoryTaskRepository : ITaskRepository
{
    private readonly List<TaskItem> _tasks = new();

    public void Add(TaskItem task)
    {
        _tasks.Add(task);
    }

    public TaskItem? GetById(Guid id)
    {
        return _tasks.FirstOrDefault(
            task => task.Id == id
        );
    }

    public IEnumerable<TaskItem> GetAll()
    {
        return _tasks;
    }
}