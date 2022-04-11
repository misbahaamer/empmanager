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

        public async Task<IEnumerable<Employee>> GetEmployeesAndTheirDependents()
        {
            List<Employee> employees = new List<Employee>();
            var emps = await _dbContext.Employees.ToListAsync();
            var deps = await _dbContext.Dependents.ToListAsync();
            
            
            foreach (var emp in emps)
            {
                employees.Add(new Employee
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    Salary = emp.Salary,
                    Dependents = deps.Where(x => x.EmployeeKey == emp.Id).ToList()
                });
            }

            return employees;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByName(string name)
        {
            var data = await _dbContext.Employees.Where(x => x.Name == name).ToListAsync();
            return data;
        }

        
    }
}
