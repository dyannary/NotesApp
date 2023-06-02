using Microsoft.AspNetCore.Components;
using Notes.Blazor.Services.Interfaces;
using Notes.DataTransferObjects.Notes;

namespace Notes.Blazor.Pages;

public partial class NotesPage
{
    [Inject] 
    public INoteService NoteService { get; set; }
    

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public IEnumerable<NoteDto>? Notes;
    public string ErrorMessage { get; set; } = string.Empty;
        
    protected override async Task OnInitializedAsync()
    {
        try
        {
            Notes = await NoteService.GetNotesAsync();
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
}