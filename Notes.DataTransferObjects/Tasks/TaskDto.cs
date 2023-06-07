using Notes.DataTransferObjects.Enums;
using Notes.DataTransferObjects.Notes;
using Notes.DataTransferObjects.NoteTags;
using System.Drawing;

namespace Notes.DataTransferObjects.Tasks;

public class TaskDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public Priority Priority { get; set; }
    public DateTime? Deadline { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsCompleted { get; set; }

    public TaskDto Clone()
    {
        return new TaskDto()
        {
            Id = Id,
            Title = Title,
            Priority = Priority,
            Deadline = Deadline,
            CreatedDate = CreatedDate,
            IsCompleted = IsCompleted
        };
    }
}
