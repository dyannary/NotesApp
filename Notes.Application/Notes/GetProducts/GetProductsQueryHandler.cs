using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Data.Persistence.Context;
using Notes.DataTransferObjects.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Notes.Application.Notes.GetProducts
{
    internal class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<NoteDto>>
    {
        private readonly NotesDbContext _notesDbContext;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(NotesDbContext notesDbContext, IMapper mapper)
        {
            _notesDbContext = notesDbContext;
            _mapper = mapper;
        }

        public async Task<List<NoteDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _notesDbContext.Notes.ToListAsync();

            return _mapper.Map<List<NoteDto>>(products);
        }
    }
}
