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

    public MudColor _pickerColor = "#27272f";

    public async Task SaveAndGoToNoteDetails()
    {
        try
        {
            int id = await NoteService.AddNoteAsync(
            new AddEditNoteDto() 
            {
                Title = NoteTitle,
                Color = _pickerColor.Value,
            });

            if (id == 0)
                throw new Exception();
            else
                NavigationManager.NavigateTo($"noteDetails/{id}");
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

    public IEnumerable<MudColor> CustomPalette { get; set; } = new MudColor[]
    {
        "#F44336", "#E91E63", "#9C27B0", "#673AB7", "#3F51B5",
        "#E57373", "#F06292", "#BA68C8", "#9575CD", "#7986CB",
        "#EF5350", "#EC407A", "#AB47BC", "#7E57C2", "#5C6BC0",
        "#E53935", "#D81B60", "#8E24AA", "#5E35B1", "#3949AB"
    };
}
