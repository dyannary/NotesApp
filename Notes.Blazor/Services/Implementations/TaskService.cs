using Notes.Blazor.Services.Interfaces;
using Notes.DataTransferObjects.Notes;
using Notes.DataTransferObjects.Tasks;
using System.Net.Http.Json;

namespace Notes.Blazor.Services.Implementations;

public class TaskService: ITaskService
{
    private readonly HttpClient _http;

    public TaskService(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<TaskDto>> GetTasksAsync()
    {
        try
        {
            var response = await _http.GetAsync("api/Tasks");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<TaskDto>();
                }

                return await response.Content.ReadFromJsonAsync<IEnumerable<TaskDto>>();
            }

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<TaskDto> GetTaskByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddTaskAsync(TaskDto myEvent)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteTaskAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateTaskAsync(TaskDto myEvent)
    {
        throw new NotImplementedException();
    }
}