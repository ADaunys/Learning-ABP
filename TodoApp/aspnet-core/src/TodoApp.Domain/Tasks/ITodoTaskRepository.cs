using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace TodoApp.Tasks
{
    public interface ITodoTaskRepository : IRepository<TodoTask, Guid>
    {
        Task<List<TodoTask>> GetAllTasks(int skipCount, int maxResultCount, string sorting, string filter = null);
    }
}
