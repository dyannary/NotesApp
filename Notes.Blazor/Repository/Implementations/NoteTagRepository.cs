using Notes.Blazor.Services.Interfaces;
using Notes.DataTransferObjects.Notes;
using Notes.DataTransferObjects.NoteTags;
using System.Net.Http.Json;

namespace Notes.Blazor.Services.Implementations;

public class NoteTagRepository: INoteTagRepository
{
    private readonly HttpClient _http;

    public NoteTagRepository(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<NoteTagDto>> GetNoteTagsAsync(int noteId)
    {
        try
        {
            var response = await _http.GetAsync($"api/NoteTags?noteId={noteId}");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<NoteTagDto>();
                }

                return await response.Content.ReadFromJsonAsync<IEnumerable<NoteTagDto>>();
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

    public async Task<int> AddNoteTagAsync(NoteTagDto noteTag)
    {
        try
        {
            var response = await _http.PostAsJsonAsync("/api/NoteTags", noteTag);

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

    public async Task DeleteNoteTagAsync(int id)
    {
        try
        {
            var response = await _http.DeleteAsync($"api/NoteTags/{id}");

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

    public async Task UpdateNoteTagAsync(NoteTagDto noteTag)
    {
        try
        {
            var response = await _http.PatchAsJsonAsync("api/NoteTags", noteTag);

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