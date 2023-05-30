﻿namespace Notes.DataTransferObjects.Events;

public class EventDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
