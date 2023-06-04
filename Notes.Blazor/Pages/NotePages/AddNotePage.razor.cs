using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Utilities;
using Notes.Blazor.Services.Interfaces;
using Notes.DataTransferObjects.Notes;
using System;

namespace Notes.Blazor.Pages.NotePages;

public partial class AddNotePage
{
    [Inject]
    public INoteService NoteService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    ISnackbar Snackbar { get; set; }

    public string NoteTitle { get; set; } = "Title";

    public bool AddSpecialColor { get; set; }

    public MudColor _pickerColor = "#594AE2";

    public async Task SaveAndGoToNoteDetails()
    {
        try
        {
            int id = await NoteService.AddNoteAsync(
            new AddEditNoteDto() { Title = NoteTitle });

            if (id != 0)
                NavigationManager.NavigateTo($"noteDetails/{id}");

            throw new Exception();
        }
        catch (Exception)
        {
            Snackbar.Add("Can not create note");
        }
    }

    public void Cancel()
    {
        NavigationManager.NavigateTo($"notes");
    }

    public void UpdateSelectedColor(MudColor value)
    {
        _pickerColor = value;
    }
}
