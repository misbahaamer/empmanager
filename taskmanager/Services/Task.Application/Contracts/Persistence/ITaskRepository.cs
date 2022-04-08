using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Entities;

namespace Task.Application.Contracts.Persistence
{
    public interface ITaskRepository : IAsyncRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetTasksByName(string name);
        Task<IEnumerable<Employee>> GetTasksByPriorityType(string priority);
        Task<IEnumerable<Employee>> GetTasksByStatus(string status);
        Task<IEnumerable<Employee>> GetTasksByDueDate(DateTime date);
        Task<Dictionary<string,int>> GetTasksCountForPriorityAndStatusOnADate();
    }
}
