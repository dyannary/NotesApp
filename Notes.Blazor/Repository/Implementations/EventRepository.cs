using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using Notes.Blazor.Services.Interfaces;
using Notes.DataTransferObjects.Events;
using Notes.DataTransferObjects.Notes;
using System.Net.Http.Json;
using System.Text;

namespace Notes.Blazor.Services.Implementations;

public class EventRepository : IEventRepository
{
    private readonly HttpClient _http;

    public EventRepository(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<EventDto>> GetEventsAsync()
    {
        try
        {
            var response = await _http.GetAsync("api/Events");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<EventDto>();
                }

                return await response.Content.ReadFromJsonAsync<IEnumerable<EventDto>>();
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

    public async Task<EventDto> GetEventByIdAsync(int id)
    {
        try
        {
            var response = await _http.GetAsync($"api/Events/{id}");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return default;
                }

                return await response.Content.ReadFromJsonAsync<EventDto>();
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
    public async Task<int> AddEventAsync(AddEditEventDto eventToAdd)
    {
        try
        {
            var response = await _http.PostAsJsonAsync("/api/Events", eventToAdd);

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

    public async Task DeleteEventAsync(int id)
    {
        try
        {
            var response = await _http.DeleteAsync($"api/Events/{id}");

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

    public async Task PartialUpdateEventAsync(AddEditEventDto myEvent)
    {
        try
        {
            var patchDoc = new JsonPatchDocument<AddEditEventDto>();
            patchDoc.Replace(e => e.Name, myEvent.Name);
            patchDoc.Replace(e => e.StartDate, myEvent.StartDate);
            patchDoc.Replace(e => e.EndDate, myEvent.EndDate);
            patchDoc.Replace(e => e.Description, myEvent.Description);

            var serializedDoc = JsonConvert.SerializeObject(patchDoc);
            var requestContent = new StringContent(serializedDoc, Encoding.UTF8, "application/json-patch+json");


            var response = await _http.PatchAsync($"api/Events/{myEvent.Id}", requestContent);

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

    public async Task UpdateEventAsync(AddEditEventDto myEvent)
    {
        try
        {
            var response = await _http.PutAsJsonAsync($"api/Events", myEvent);

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
