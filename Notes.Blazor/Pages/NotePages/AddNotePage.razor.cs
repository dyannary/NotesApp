using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Utilities;
using Notes.Blazor.Services.Interfaces;
using Notes.DataTransferObjects.Notes;
using System;
using Notes.Blazor.Builder;

namespace Notes.Blazor.Pages.NotePages;

public partial class AddNotePage
{
    [Inject]
    public INoteService NoteService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    private string _noteTitle { get; set; } = "Title";

    private bool _addSpecialColor { get; set; }

    private MudColor _pickerColor = "#27272f";

    private NoteBuilder _noteBuilder { get; }

    public AddNotePage()
    {
        _noteBuilder = new NoteBuilder();
    }

    public async Task SaveAndGoToNoteDetails()
    {
        try
        {
            int id = await NoteService.AddNoteAsync(
            new AddEditNoteDto() 
            {
                Title = _noteTitle,
                Color = _pickerColor.Value,
            });

            if (id == 0)
                throw new Exception();
            
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
