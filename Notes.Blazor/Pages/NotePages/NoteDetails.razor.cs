using Microsoft.AspNetCore.Components;
using Notes.Blazor.Services.Interfaces;
using Notes.DataTransferObjects.Notes;
using Notes.DataTransferObjects.NoteTags;

namespace Notes.Blazor.Pages.NotePages;
    
public partial class NoteDetails
{
    [Parameter]
    public int Id { get; set; }
    [Inject]
    public INoteRepository NoteRepository { get; set; }

    [Inject]
    public INoteTagRepository NoteTagRepository { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public NoteDto? Note { get; set; }

    public List<NoteTagDto> NoteTags { get; set; } = new List<NoteTagDto>();

    public string ErrorMessage { get; set; } = string.Empty;

    public bool StartAddTag { get; set; } = false;

    public string NewTagName { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Note = await NoteRepository.GetNoteByIdAsync(Id);
            await GetNoteTags();
        }
        catch (Exception e)
        {
            ErrorMessage = e.Message;
        }
    }

    public async Task GetNoteTags()
    {
        var res = await NoteTagRepository.GetNoteTagsAsync(Note.Id);

        if (res.Any())
        {
            NoteTags = (List<NoteTagDto>)res;
        }
    }

    public async Task ChangeNoteTitle()
    {
        var noteToEdit = new AddEditNoteDto()
        {
            Id = Note.Id,
            Title = Note.Title
        };

        await NoteRepository.UpdateNoteAsync(noteToEdit);
    }

    public async Task ChangeNoteContent()
    {
        var noteToEdit = new AddEditNoteDto()
        {
            Id = Note.Id,
            Content = Note.Content
        };

        await NoteRepository.UpdateNoteAsync(noteToEdit);
    }

    private void GoToNotePage()
    {
        NavigationManager.NavigateTo("notes");
    }

    public void AddTag()
    {
        StartAddTag = true;
    }

    public async Task SaveTag()
    {
        var noteTag = new NoteTagDto()
        {
            Title = NewTagName,
            NoteId = Note.Id,
            Color = new Random().Next(10)
        };

        NoteTags.Add(noteTag);

        await NoteTagRepository.AddNoteTagAsync(noteTag);

        NewTagName = string.Empty;
        StartAddTag = false;
    }

    public async Task DeleteTag(NoteTagDto tagToDelete)
    {
        await NoteTagRepository.DeleteNoteTagAsync(tagToDelete.Id);

        NoteTags.Remove(tagToDelete);

        await GetNoteTags();
    }
}