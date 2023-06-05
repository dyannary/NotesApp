using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Notes.DataTransferObjects.Events;

namespace Notes.Application.Events.PatchEvent;

public class PatchEventCommand : IRequest<int?>
{
    public int EventId { get; set; }
    public JsonPatchDocument<AddEditEventDto> PatchDoc { get; set; }
        
    public PatchEventCommand(int eventId, JsonPatchDocument<AddEditEventDto> patchDoc)
    {
        EventId = eventId;
        PatchDoc = patchDoc;
    }
}
