using Microsoft.AspNetCore.Components;
using Notes.Blazor.Services.Interfaces;
using Notes.DataTransferObjects.Tasks;

namespace Notes.Blazor.Pages.TaskPages;

public partial class TasksPage
{
    [Inject]
    public ITaskService TaskService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }
        
    public List<TaskDto> Tasks { get; set; } = new();
    public string ErrorMessage { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await GetTasks();
    }
        
    private async Task GetTasks()
    {
        try
        {
            Tasks = (List<TaskDto>)await TaskService.GetTasksAsync();
        }
        catch (Exception e)
        {
            ErrorMessage = e.Message;
        }
    }   

    private void NewTask()
    {
        throw new NotImplementedException();
    }
}