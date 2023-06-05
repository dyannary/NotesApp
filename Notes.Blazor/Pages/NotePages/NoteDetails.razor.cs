using Microsoft.AspNetCore.Components;
using Notes.Blazor.Services.Interfaces;
using Notes.DataTransferObjects.Notes;

namespace Notes.Blazor.Pages.NotePages;
    
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
        var noteToEdit = new AddEditNoteDto()
        {
            Id = Note.Id,
            Title = Note.Title
        };

        await NoteService.UpdateNoteAsync(noteToEdit);
    }

    public async Task ChangeNoteContent()
    {
        var noteToEdit = new AddEditNoteDto()
        {
            Id = Note.Id,
            Content = Note.Content
        };

        await NoteService.UpdateNoteAsync(noteToEdit);
    }

    private void GoToNotePage()
    {
        NavigationManager.NavigateTo("notes");
    }
}