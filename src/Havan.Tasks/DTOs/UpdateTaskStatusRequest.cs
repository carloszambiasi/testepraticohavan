using Havan.Tasks.Domain.Enums;

namespace Havan.Tasks.DTOs;

public class UpdateTaskStatusRequest
{
    public TodoTaskStatus Status { get; set; }
}