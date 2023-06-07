using Notes.DataTransferObjects.Enums;

namespace Notes.DataTransferObjects.Tasks;

public class AddEditTaskDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public Priority Priority { get; set; }
    public DateTime? Deadline { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsCompleted { get; set; }
}
