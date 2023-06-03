using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.DataTransferObjects.Tasks;
using Notes.Persistence.Context;

namespace Notes.Application.Tasks.GetTask;

public class GetTaskQueryHandler : IRequestHandler<GetTaskQuery, TaskDto?>
{
    private readonly NotesDbContext _notesDbContext;
    private readonly IMapper _mapper;

    public GetTaskQueryHandler(NotesDbContext notesDbContext, IMapper mapper)
    {
        _notesDbContext = notesDbContext;
        _mapper = mapper;
    }
    public async Task<TaskDto?> Handle(GetTaskQuery request, CancellationToken cancellationToken)
    {
        var task = await _notesDbContext.Tasks
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        return _mapper.Map<TaskDto?>(task);
    }
}