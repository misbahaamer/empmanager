using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Entities;

namespace Task.Application.Contracts.Persistence
{
    public interface IEmployeeRepository : IAsyncRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetEmployeesByName(string name);
        Task<IEnumerable<Employee>> GetEmployeesAndTheirDependents();

    }
}
