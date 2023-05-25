using MediatR;
using Notes.DataTransferObjects.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.GetProducts
{
    public record GetProductsQuery : IRequest<List<NoteDto>>;
}
