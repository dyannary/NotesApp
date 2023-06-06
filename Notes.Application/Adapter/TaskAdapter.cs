using AutoMapper;
using Notes.DataTransferObjects.Tasks;

namespace Notes.Application.Adapter;

public class TaskAdapter : ITypeConverter<AddEditTaskDto, Domain.Task>, ITypeConverter<Domain.Task, TaskDto>
{
    public Domain.Task Convert(AddEditTaskDto source, Domain.Task destination, ResolutionContext context)
    {
        var task = new Domain.Task
        {
            Id = source.Id,
            Title = source.Title,
            Content = source.Content,
            Priority = source.Priority,
            Deadline = source.Deadline,
            CreatedDate = source.CreatedDate,
            IsCompleted = source.IsCompleted
        };

        return task;
    }

    public TaskDto Convert(Domain.Task source, TaskDto destination, ResolutionContext context)
    {
        var taskDto = new TaskDto
        {
            Id = source.Id,
            Title = source.Title,
            Content = source.Content,
            Priority = source.Priority,
            Deadline = source.Deadline,
            CreatedDate = source.CreatedDate,
            IsCompleted = source.IsCompleted
        };

        return taskDto;
    }
}