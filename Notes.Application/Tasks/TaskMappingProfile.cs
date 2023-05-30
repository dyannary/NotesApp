﻿using AutoMapper;
using Notes.DataTransferObjects.Tasks;
namespace Notes.Application.Tasks;

public class TaskMappingProfile : Profile
{
    public TaskMappingProfile()
    {
        CreateMap<AddEditTaskDto, Domain.Task>()
            .ForMember(x => x.Title, opts => opts.MapFrom(op => op.Title))
            .ForMember(x => x.Content, opts => opts.MapFrom(op => op.Content))
            .ForMember(x => x.Priority, opts => opts.MapFrom(op => op.Priority))
            .ForMember(x => x.Deadline, opts => opts.MapFrom(op => op.Deadline));

        CreateMap<Domain.Task, TaskDto>()
            .ForMember(x => x.Title, opts => opts.MapFrom(op => op.Title))
            .ForMember(x => x.Content, opts => opts.MapFrom(op => op.Content))
            .ForMember(x => x.Priority, opts => opts.MapFrom(op => op.Priority))
            .ForMember(x => x.Deadline, opts => opts.MapFrom(op => op.Deadline));
    }
}