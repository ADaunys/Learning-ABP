using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using TodoApp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace TodoApp.Tasks
{
    public class EfCoreTodoTaskRepository : EfCoreRepository<TodoAppDbContext, TodoTask, Guid>, ITodoTaskRepository
    {
        public EfCoreTodoTaskRepository(IDbContextProvider<TodoAppDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task<List<TodoTask>> GetAllTasks(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(!filter.IsNullOrWhiteSpace(), t => t.Title.Contains(filter) || t.Description.Contains(filter))
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }

        public async Task<TodoTask> GetTaskById(Guid id)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
