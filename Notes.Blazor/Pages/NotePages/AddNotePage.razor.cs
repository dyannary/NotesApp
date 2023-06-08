using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Utilities;
using Notes.Blazor.Services.Interfaces;
using Notes.DataTransferObjects.Notes;
using System;
using Notes.Blazor.Builder;
using Notes.Blazor.Services.Implementations;
using Notes.DataTransferObjects.NoteTags;

namespace Notes.Blazor.Pages.NotePages;

public partial class AddNotePage
{
    [Inject]
    public INoteRepository NoteRepository { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    [Inject]
    public ISnackbar Snackbar { get; set; }

    private string _noteTitle { get; set; }

    private bool _addNoteContent { get; set; }
    private string _noteContent { get; set; }

    private bool _addSpecialColor { get; set; }
    private MudColor _selectedColor;

    private bool _addTags { get; set; }
    private string _tagNameToAdd { get; set; }

    private List<NoteTagDto> _noteTags { get; set; } = new();

    private NoteBuilder _noteBuilder { get; }

    public AddNotePage()
    {
        _noteTitle = "New Note";
        _selectedColor = "#27272f";

        _noteBuilder = new NoteBuilder();

        _noteBuilder.AddBorderColor("#27272f");
    }

    public void UpdateSelectedColor(MudColor value)
    {
        _selectedColor = value;
    }

    public async Task SaveAndGoToNoteDetails()
    {
        try
        {
            _noteBuilder.AddTitle(_noteTitle);

            if (_addNoteContent)
                _noteBuilder.AddContent(_noteContent);

            if (_addTags)
            {
                foreach (var tag in _noteTags)
                {
                    _noteBuilder.AddTag(tag);
                }
            }

            if (_addSpecialColor)
                _noteBuilder.AddBorderColor(_selectedColor.Value);

            var noteToAdd = _noteBuilder.Build();

            int id = await NoteRepository.AddNoteAsync(noteToAdd);

            if (id == 0)
                throw new Exception();
            
            NavigationManager.NavigateTo($"noteDetails/{id}");
        }
        catch (Exception)
        {
            Snackbar.Add("Can not create note");
        }
    }

    public void SaveTag()
    {
        if (string.IsNullOrWhiteSpace(_tagNameToAdd))
            return;

        var noteTag = new NoteTagDto()
        {
            Title = _tagNameToAdd,
            Color = new Random().Next(10)
        };

        _noteTags.Add(noteTag);
        _tagNameToAdd = string.Empty;
    }

    public void DeleteTag(NoteTagDto tagToDelete)
    {
        _noteTags.Remove(tagToDelete);
    }

    public void Cancel()
    {
        NavigationManager.NavigateTo($"notes");
    }

    public IEnumerable<MudColor> CustomPalette { get; set; } = new MudColor[]
    {
        "#F44336", "#E91E63", "#9C27B0", "#673AB7", "#3F51B5",
        "#E57373", "#F06292", "#BA68C8", "#9575CD", "#7986CB",
        "#EF5350", "#EC407A", "#AB47BC", "#7E57C2", "#5C6BC0",
        "#E53935", "#D81B60", "#8E24AA", "#5E35B1", "#3949AB"
    };
}
