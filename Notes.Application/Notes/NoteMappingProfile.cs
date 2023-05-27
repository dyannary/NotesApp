using AutoMapper;
using Notes.DataTransferObjects.Notes;
using Notes.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes
{
    public class NoteMappingProfile : Profile
    {
        public NoteMappingProfile()
        {
            CreateMap<AddEditNoteDto, Note>()
                .ForMember(x => x.Id, opts => opts.Ignore())
                .ForMember(x => x.Title, opts => opts.MapFrom(op => op.Title))
                .ForMember(x => x.Description, opts => opts.MapFrom(op => op.Description));

            CreateMap<Note, NoteDto>()
                .ForMember(x => x.Id, opts => opts.MapFrom(op => op.Id))
                .ForMember(x => x.Title, opts => opts.MapFrom(op => op.Title))
                .ForMember(x => x.Description, opts => opts.MapFrom(op => op.Description));
        }
    }
}
