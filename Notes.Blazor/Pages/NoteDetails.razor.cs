using Microsoft.AspNetCore.Components;
using Notes.Blazor.Services.Interfaces;
using Notes.DataTransferObjects.Notes;

namespace Notes.Blazor.Pages;

public partial class NoteDetails
{
    [Parameter]
    public int Id { get; set; }
    [Inject]
    public INoteService NoteService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public NoteDto? Note { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Note = await NoteService.GetNoteByIdAsync(Id);
        }
        catch (Exception e)
        {
            ErrorMessage = e.Message;
        }
    }

    public async Task ChangeNoteTitle()
    {

    }

    public async Task ChangeNoteContent()
    {

    }

    private void GoToNotePage()
    {
        NavigationManager.NavigateTo("notes");
    }
}