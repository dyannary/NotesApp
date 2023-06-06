using Notes.DataTransferObjects.Tasks;

namespace Notes.Blazor.Services.Interfaces;

public interface ITaskService
{   
    Task<IEnumerable<TaskDto>> GetTasksAsync();
    Task<TaskDto> GetTaskByIdAsync(int id);
    Task<int> AddTaskAsync(TaskDto myEvent);
    Task DeleteTaskAsync(int id);
    Task UpdateTaskAsync(TaskDto myEvent);
}