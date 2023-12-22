using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace TodoApp.Tasks
{
    public class GetTodoTaskListDto : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
