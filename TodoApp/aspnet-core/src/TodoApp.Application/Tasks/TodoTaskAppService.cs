using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace TodoApp.Tasks
{
    public class TodoTaskAppService : ApplicationService, ITodoTaskAppService
    {
        private readonly ITodoTaskRepository _todoTaskRepository;

        public TodoTaskAppService(ITodoTaskRepository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }

        public async Task<PagedResultDto<TodoTaskDto>> GetAllTasks(GetTodoTaskListDto input)
        {
            if(input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(TodoTask.Title);
            }

            var tasks = await _todoTaskRepository.GetAllTasks(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _todoTaskRepository.CountAsync()
                : await _todoTaskRepository.CountAsync(task => task.Title.Contains(input.Filter)
            );

            return new PagedResultDto<TodoTaskDto>(
                totalCount,
                ObjectMapper.Map<List<TodoTask>, List<TodoTaskDto>>(tasks)
            );
        }

        public async Task<TodoTaskDto> GetTaskById(Guid id)
        {
            var task = await _todoTaskRepository.GetAsync(id);
            return ObjectMapper.Map<TodoTask, TodoTaskDto>(task);
        }

        public async Task CreateTask(TodoTask input)
        {
            await _todoTaskRepository.InsertAsync(input);
        }

        public async Task UpdateTask(TodoTask input)
        {
            await _todoTaskRepository.UpdateAsync(input);
        }

        public async Task DeleteTask(Guid id)
        {
            await _todoTaskRepository.DeleteAsync(id);
        }
    }
}
