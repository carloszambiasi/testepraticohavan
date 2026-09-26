using Havan.Tasks.Domain.Enums;
using Havan.Tasks.Repositories;
using Havan.Tasks.Services;

namespace Havan.Tasks.Tests.Services;

public class TaskServiceTests
{
    private readonly InMemoryTaskRepository _repository;
    private readonly TaskService _service;

    public TaskServiceTests()
    {
        _repository = new InMemoryTaskRepository();
        _service = new TaskService(_repository);
    }

    [Fact]
    public void Create_ShouldAddTaskToRepository()
    {
        var task = _service.Create(
            "Estudar C#",
            "Revisar orientação a objetos"
        );

        var savedTask = _repository.GetById(task.Id);

        Assert.NotNull(savedTask);
        Assert.Equal(task.Id, savedTask.Id);
    }

    [Fact]
    public void GetActiveTasks_ShouldReturnPendingAndInProgressTasks()
    {
        _service.Create(
            "Tarefa pendente",
            "Descrição"
        );

        var inProgress = _service.Create(
            "Tarefa andamento",
            "Descrição"
        );

        _service.UpdateStatus(
            inProgress.Id,
            TodoTaskStatus.EmAndamento
        );

        var completed = _service.Create(
            "Tarefa concluída",
            "Descrição"
        );

        _service.UpdateStatus(
            completed.Id,
            TodoTaskStatus.Concluida
        );

        var result = _service
            .GetActiveTasks()
            .ToList();

        Assert.Equal(2, result.Count);

        Assert.DoesNotContain(
            result,
            task => task.Status == TodoTaskStatus.Concluida
        );
    }

    [Fact]
    public void UpdateStatus_WithInvalidId_ShouldThrowException()
    {
        Assert.Throws<KeyNotFoundException>(() =>
            _service.UpdateStatus(
                Guid.NewGuid(),
                TodoTaskStatus.EmAndamento
            )
        );
    }

    [Fact]
    public void GetCompletedTasks_WithInvalidDateRange_ShouldThrowException()
    {
        var startDate = new DateTime(2026, 10, 20);
        var endDate = new DateTime(2026, 10, 10);

        Assert.Throws<ArgumentException>(() =>
            _service.GetCompletedTasks(
                startDate,
                endDate
            )
        );
    }

    [Fact]
    public void GetCompletedTasks_ShouldReturnCompletedTasksInDateRange()
    {
        var task = _service.Create(
            "Tarefa concluída",
            "Descrição"
        );

        _service.UpdateStatus(
            task.Id,
            TodoTaskStatus.Concluida
        );

        var startDate = DateTime.UtcNow.AddMinutes(-1);
        var endDate = DateTime.UtcNow.AddMinutes(1);

        var result = _service
            .GetCompletedTasks(startDate, endDate)
            .ToList();

        Assert.Single(result);
        Assert.Equal(task.Id, result[0].Id);
    }
}