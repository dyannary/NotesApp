﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces.Messaging;
using Notes.DataTransferObjects.Notes;
using Notes.Persistence.Context;

namespace Notes.Application.Notes.GetNotes;

public class GetNotesQueryHandler : IQueryHandler<GetNotesQuery, IEnumerable<NoteDto>>
{
    private readonly NotesDbContext _notesDbContext;
    private readonly IMapper _mapper;

    public GetNotesQueryHandler(NotesDbContext notesDbContext, IMapper mapper)
    {
        _notesDbContext = notesDbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<NoteDto>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
    {
        var notes = await _notesDbContext.Notes.ToListAsync(cancellationToken: cancellationToken);

        return _mapper.Map<List<NoteDto>>(notes);
    }
}