using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Extensions;
using MudBlazor.Utilities;
using Notes.Blazor.Services.Interfaces;
using Notes.DataTransferObjects.Enums;
using Notes.DataTransferObjects.Tasks;
using System.Drawing;
using Microsoft.AspNetCore.Components.Web;
using Notes.Blazor.Decorator;
using static MudBlazor.Defaults.Classes;
using Color = MudBlazor.Color;

namespace Notes.Blazor.Pages.TaskPages;

public partial class TasksPage
{
    [Inject]
    public ITaskService TaskService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    [Inject]
    ISnackbar Snackbar { get; set; }

    public ITaskListDecorator Tasks { get; set; } = new TaskList();
    public string ErrorMessage { get; set; } = string.Empty;

    public bool StartAddTask { get; set; } = false;
    public bool AddDeadLine { get; set; } = false;
    public TaskDto NewTaskDto { get; set; }

    public bool HighPriority { get; set; } = true; 
    public bool MidPriority { get; set; } = true;
    public bool LowPriority { get; set; } = true;
    public bool NonePriority { get; set; } = true;
    public bool OnlyNotCompleted { get; set; } = false;
    public bool ByPriority { get; set; } = false;
    public bool ByTimeLeft { get; set; } = false;

    public List<TaskDto> DecoratedTasks { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await GetTasks();
    }
        
    private async Task GetTasks()
    {
        try
        {
            Tasks = await TaskService.GetTasksAsync();

            /*DecoratedTasks= new List<TaskDto>();

            foreach (var task in Tasks.GetTasks())
            {
                DecoratedTasks.Add(task.Clone());
            }*/
        }
        catch (Exception e)
        {
            ErrorMessage = e.Message;
        }
    }   

    private void NewTask()
    {
        NewTaskDto = new TaskDto()
        {
            Priority = Priority.None,
        };

        StartAddTask = true;
    }

    private void CancelAddTask()
    {
        NewTaskDto = new TaskDto();
        StartAddTask = false;
    }

    private async Task AddTask()
    {
        if (string.IsNullOrEmpty(NewTaskDto.Title))
            return;

        try
        {
            await TaskService.AddTaskAsync(NewTaskDto);
            Tasks.Add(NewTaskDto);
            StartAddTask = false;
        }
        catch (Exception e)
        {
            ErrorMessage = e.Message;
            Snackbar.Clear();
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomStart;
            Snackbar.Add(ErrorMessage, Severity.Error);
        }
    }

    private string GetColorByPriority(Priority priority)
    {
        string color = "#9E9E9E"; ;
        switch (priority)
        {
            case Priority.High:
                color = "#776be7";
                break;
            case Priority.Medium:
                color = "#ff4081";
                break;
            case Priority.Low:
                color = "#0bba83";
                break;
            case Priority.None:
                color = "#9E9E9E";
                break;
        }

        return new MudColor(color).ToString();
    }

    private string DaysLeft(DateTime? deadline)
    {
        if (deadline == null)   
            return string.Empty;

        var timeSpan = ((DateTime)deadline).Subtract(DateTime.Now);

        var d = timeSpan.Days > 1 ? "days" : "day";
        return $"Time left: {timeSpan.Days + 1} {d}";
    }

    private Color GetColorEnum(Priority priority)
    {
        switch (priority)
        {   
            case Priority.High:
                return Color.Error;
            case Priority.Medium:
                return Color.Warning;
            case Priority.Low:
                return Color.Success;
            case Priority.None:
                return Color.Default;
        }
        return Color.Default;
    }

    private void FilterByPriority()
    {   
        Tasks = new TaskListOrderByPriority(Tasks);
    }

    private void FilterByHighPriority() 
    {
        Tasks = new TaskListFilterByHighPriority(Tasks);
    }
}   