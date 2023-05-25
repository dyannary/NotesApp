using MediatR;
using Notes.DataTransferObjects.Notes;
using Notes.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.AddNote
{
    public class AddNoteCommand : IRequest<int>
    {
        public AddNoteCommand(AddEditNoteDto data)
        {
            Data = data;   
        }
        public AddEditNoteDto Data { get; set; }
    }
}
