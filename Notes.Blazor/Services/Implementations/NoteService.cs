using System.Collections.Generic;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Notes.Blazor.Services.Interfaces;
using Notes.DataTransferObjects.Notes;

namespace Notes.Blazor.Services.Implementations;

public class NoteService : INoteService
{

    private readonly HttpClient _http;

    public NoteService(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<NoteDto>> GetNotesAsync()
    {
        try
        {
            var response = await _http.GetAsync("api/Notes");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<NoteDto>();
                }

                return await response.Content.ReadFromJsonAsync<IEnumerable<NoteDto>>();
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

    public async Task<NoteDto> GetNoteByIdAsync(int id)
    {
        try
        {
            var response = await _http.GetAsync($"api/Notes/{id}");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return default;
                }

                return await response.Content.ReadFromJsonAsync<NoteDto>();
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

    public async Task<int> AddNoteAsync(AddEditNoteDto noteToAdd)
    {
        try
        {
            var response = await _http.PostAsJsonAsync("/api/Notes", noteToAdd);

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

    public async Task DeleteNoteAsync(int id)
    {
        try
        {
            var response = await _http.DeleteAsync($"api/Notes/{id}");

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

    public async Task UpdateNoteAsync(AddEditNoteDto note)
    {
        try
        {
            var response = await _http.PatchAsJsonAsync("api/Notes", note);

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