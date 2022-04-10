using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;
using Task.Domain.Entities;
using Task.Infrastructure.Persistance;

namespace Task.Infrastructure.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(TaskContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByName(string name)
        {
            var data = await _dbContext.Employees.Where(x => x.Name == name).ToListAsync();
            return data;
        }

        
    }
}
