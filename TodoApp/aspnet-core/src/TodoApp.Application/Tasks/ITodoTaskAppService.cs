using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TodoApp.Tasks
{
    public interface ITodoTaskAppService : IApplicationService
    {
        Task<PagedResultDto<TodoTaskDto>> GetAllTasks(GetTodoTaskListDto input);
        Task<TodoTaskDto> GetTaskById(Guid id);
        Task CreateTask(TodoTask input);
        Task UpdateTask(TodoTask input);
        Task DeleteTask(Guid id);
    }
}
