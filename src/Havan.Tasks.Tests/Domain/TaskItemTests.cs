using Havan.Tasks.Domain.Entities;
using Havan.Tasks.Domain.Enums;

namespace Havan.Tasks.Tests.Domain;

public class TaskItemTests
{
    [Fact]
    public void Create_WithValidData_ShouldCreatePendingTask()
    {
        // Arrange
        var title = "Estudar C#";
        var description = "Revisar orientação a objetos";

        // Act
        var task = new TaskItem(title, description);

        // Assert
        Assert.NotEqual(Guid.Empty, task.Id);
        Assert.Equal(title, task.Title);
        Assert.Equal(description, task.Description);
        Assert.Equal(TodoTaskStatus.Pendente, task.Status);
        Assert.Null(task.CompletedAt);
    }

    [Fact]
    public void Create_WithEmptyTitle_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() =>
            new TaskItem("", "Descrição")
        );
    }

    [Fact]
    public void Create_WithTitleShorterThanFiveCharacters_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() =>
            new TaskItem("abc", "Descrição")
        );
    }

    [Fact]
    public void UpdateStatus_ToInProgress_ShouldNotSetCompletedAt()
    {
        // Arrange
        var task = new TaskItem(
            "Estudar C#",
            "Revisar orientação a objetos"
        );

        // Act
        task.UpdateStatus(TodoTaskStatus.EmAndamento);

        // Assert
        Assert.Equal(TodoTaskStatus.EmAndamento, task.Status);
        Assert.Null(task.CompletedAt);
    }

    [Fact]
    public void UpdateStatus_ToCompleted_ShouldSetCompletedAt()
    {
        // Arrange
        var task = new TaskItem(
            "Estudar C#",
            "Revisar orientação a objetos"
        );

        // Act
        task.UpdateStatus(TodoTaskStatus.Concluida);

        // Assert
        Assert.Equal(TodoTaskStatus.Concluida, task.Status);
        Assert.NotNull(task.CompletedAt);
    }

    [Fact]
    public void UpdateStatus_WhenAlreadyCompleted_ShouldThrowException()
    {
        // Arrange
        var task = new TaskItem(
            "Estudar C#",
            "Revisar orientação a objetos"
        );

        task.UpdateStatus(TodoTaskStatus.Concluida);

        // Act + Assert
        Assert.Throws<InvalidOperationException>(() =>
            task.UpdateStatus(TodoTaskStatus.EmAndamento)
        );
    }
}