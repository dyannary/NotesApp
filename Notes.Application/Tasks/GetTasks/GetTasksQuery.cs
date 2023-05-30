using Notes.Application.Interfaces.Messaging;
using Notes.DataTransferObjects.Tasks;

namespace Notes.Application.Tasks.GetTasks;

public record GetTasksQuery : IQuery<List<TaskDto>>;
