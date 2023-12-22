using AutoMapper;
using TodoApp.Tasks;

namespace TodoApp;

public class TodoAppApplicationAutoMapperProfile : Profile
{
    public TodoAppApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<TodoTask, TodoTaskDto>();
    }
}
