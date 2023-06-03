using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces.Messaging;
using Notes.DataTransferObjects.Tasks;
using Notes.Persistence.Context;

namespace Notes.Application.Tasks.GetTasks;

public class GetTasksQueryHandler : IQueryHandler<GetTasksQuery, IEnumerable<TaskDto>>
{
    private readonly NotesDbContext _notesDbContext;
    private readonly IMapper _mapper;

    public GetTasksQueryHandler(NotesDbContext notesDbContext, IMapper mapper)
    {
        _notesDbContext = notesDbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TaskDto>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _notesDbContext.Tasks.ToListAsync(cancellationToken: cancellationToken);

        return _mapper.Map<List<TaskDto>>(tasks);
    }
}