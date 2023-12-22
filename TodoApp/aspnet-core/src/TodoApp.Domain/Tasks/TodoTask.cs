using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace TodoApp.Tasks
{
    public class TodoTask : AuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public TodoTask()
        {

        }

        public TodoTask(
            Guid id,
            [NotNull] string title,
            [CanBeNull] string description,
            DateTime dueDate) : base(id)
        {
            Id = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
        }
    }
}
