using Notes.Blazor.Decorator;
using Notes.DataTransferObjects.Tasks;

namespace Notes.Blazor.Services.Interfaces;

public interface ITaskService
{   
    Task<TaskList> GetTasksAsync();
    Task<TaskDto> GetTaskByIdAsync(int id);
    Task<int> AddTaskAsync(TaskDto taskToAdd);
    Task DeleteTaskAsync(int id);
    Task UpdateTaskAsync(TaskDto taskToUpdate);
}   