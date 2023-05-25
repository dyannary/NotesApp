using AutoMapper;
using MediatR;
using Notes.Data.Persistence.Context;
using Notes.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.AddNote
{
    public class AddNoteCommandHandler : IRequestHandler<AddNoteCommand, int>
    {
        private readonly NotesDbContext _notesDbContext;
        private readonly IMapper _mapper;

        public AddNoteCommandHandler(NotesDbContext notesDbContext, IMapper mapper)
        {
            _notesDbContext = notesDbContext;
            _mapper = mapper;   
        }
        public async Task<int> Handle(AddNoteCommand request, CancellationToken cancellationToken)
        {
            var noteToCreate = _mapper.Map<Note>(request.Data);

            await _notesDbContext.Notes.AddAsync(noteToCreate);
            await _notesDbContext.SaveChangesAsync();

            return noteToCreate.Id;

        }
    }
}
