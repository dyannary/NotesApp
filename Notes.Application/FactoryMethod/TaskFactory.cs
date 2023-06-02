using Notes.DataTransferObjects.Enums;
using Notes.DataTransferObjects.Tasks;
using Notes.Domain;

namespace Notes.Application.FactoryMethod;

internal class TaskFactory: INoteFactory
{
    public TaskFactory(AddEditTaskDto taskToCreate)
    {
        _taskToCreate = taskToCreate;
    }

    private readonly AddEditTaskDto _taskToCreate;

    public Entity Create()
    {
        Entity task = new Domain.Task
        {
            Title = _taskToCreate.Title,
            Content = _taskToCreate.Content,
            Priority = _taskToCreate.Priority,
            Deadline = _taskToCreate.Deadline
        };
        return task;
    }
}