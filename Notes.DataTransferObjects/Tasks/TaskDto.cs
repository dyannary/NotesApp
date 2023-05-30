using Notes.DataTransferObjects.Enums;

namespace Notes.DataTransferObjects.Tasks;

public class TaskDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public Priority Priority { get; set; }
    public DateTime Deadline { get; set; }
}
