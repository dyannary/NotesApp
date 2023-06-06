using AutoMapper;
using Notes.Application.Adapter;
using Notes.DataTransferObjects.Tasks;
namespace Notes.Application.Tasks;

public class TaskMappingProfile : Profile
{
    public TaskMappingProfile()
    {
        CreateMap<AddEditTaskDto, Domain.Task>().ConvertUsing<TaskAdapter>();
        CreateMap<Domain.Task, TaskDto>().ConvertUsing<TaskAdapter>();
    }
}
