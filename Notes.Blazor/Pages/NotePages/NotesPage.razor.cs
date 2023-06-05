using Microsoft.AspNetCore.Components;
using MudBlazor;
using Notes.Blazor.Services.Interfaces;
using Notes.DataTransferObjects.Notes;

namespace Notes.Blazor.Pages.NotePages;

public partial class NotesPage
{
    [Inject]
    public INoteService NoteService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    ISnackbar Snackbar { get; set; }

    public List<NoteDto>? Notes;
    public string ErrorMessage { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await GetNotes();
    }

    private async Task GetNotes()
    {
        try
        {
            Notes = (List<NoteDto>?)await NoteService.GetNotesAsync();

            foreach (var note in Notes)
            {
                if (string.IsNullOrEmpty(note.Color))
                {
                    note.Color = "#c5c5db";
                }
            }
        }
        catch (Exception e)
        {
            ErrorMessage = e.Message;
        }
    }

    private void NewNote()
    {
        NavigationManager.NavigateTo("newNote");
    }

    private void NoteDetails(int id)
    {
        NavigationManager.NavigateTo($"noteDetails/{id}");
    }

    private async Task DeleteNote(NoteDto note)
    {
        try
        {
            await NoteService.DeleteNoteAsync(note.Id);
            Snackbar.Add("Deleted");

            Notes.Remove(note);

            //await GetNotes();
        }
        catch (Exception)
        {
            Snackbar.Add("Can not delete");
        }
    }
}