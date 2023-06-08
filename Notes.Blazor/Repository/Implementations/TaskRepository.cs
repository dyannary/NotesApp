using Notes.Blazor.Services.Interfaces;
using Notes.DataTransferObjects.Notes;
using Notes.DataTransferObjects.Tasks;
using System.Net.Http.Json;
using Notes.Blazor.Decorator;

namespace Notes.Blazor.Services.Implementations;

public class TaskRepository: ITaskRepository
{
    private readonly HttpClient _http;

    public TaskRepository(HttpClient http)
    {
        _http = http;
    }

    public async Task<TaskList> GetTasksAsync()
    {
        try
        {
            var response = await _http.GetAsync("api/Tasks");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new TaskList(new List<TaskDto>());
                }

                var tasks = await response.Content.ReadFromJsonAsync<IEnumerable<TaskDto>>();
                return new TaskList(tasks!.ToList());
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

    public async Task<int> AddTaskAsync(TaskDto taskToAdd)
    {
        try
        {
            var response = await _http.PostAsJsonAsync("/api/Tasks", taskToAdd);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<int>();
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

    public async Task DeleteTaskAsync(int id)
    {
        try
        {
            var response = await _http.DeleteAsync($"api/Tasks/{id}");

            if (!response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task UpdateTaskAsync(TaskDto taskToUpdate)
    {
        try
        {
            var response = await _http.PatchAsJsonAsync("api/Tasks", taskToUpdate);

            if (!response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}