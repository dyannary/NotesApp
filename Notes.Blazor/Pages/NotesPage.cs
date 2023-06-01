using System.Net.Http.Json;
using Notes.DataTransferObjects.Notes;

namespace Notes.Blazor.Pages;

public partial class NotesPage
{
    private const string _noteEndPoint = "api/Notes";

    private IEnumerable<NoteDto>? _notesList;

    protected override async Task OnInitializedAsync()
    {
        await GetNotes();
    }

    private void NewNote()
    {
        NavigationManager.NavigateTo("newNote");
    }

    private async Task GetNotes()
    {
        _notesList = await Http.GetFromJsonAsync<IEnumerable<NoteDto>>(_noteEndPoint);
    }
}