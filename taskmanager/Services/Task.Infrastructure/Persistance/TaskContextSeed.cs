using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Entities;

namespace Task.Infrastructure.Persistance
{
    public class TaskContextSeed
    {
        public static async System.Threading.Tasks.Task SeedAsync(TaskContext taskContext, ILogger<TaskContextSeed> logger)
        {
            if (!taskContext.Employees.Any())
            {
                taskContext.Employees.AddRange(GetPreconfiguredEmployees());
                await taskContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(TaskContext).Name);
            }
        }

        private static IEnumerable<Employee> GetPreconfiguredEmployees()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Name = "Name" +DateTime.Today.Date +DateTime.Today.Millisecond.ToString(),
                    Salary = 2000
                },
                new Employee
                {
                    Name = "Name" +DateTime.Today.Date +DateTime.Today.Millisecond.ToString(),
                    Salary = 2000
                },
                new Employee
                {
                    Name = "Name" +DateTime.Today.Date +DateTime.Today.Millisecond.ToString(),
                    Salary = 2000
                },
                new Employee
                {
                    Name = "Name" +DateTime.Today.Date +DateTime.Today.Millisecond.ToString(),
                    Salary = 2000
                },
                new Employee
                {
                    Name = "Name" +DateTime.Today.Date +DateTime.Today.Millisecond.ToString(),
                    Salary = 2000
                },
                new Employee
                {
                    Name = "Name" +DateTime.Today.Date +DateTime.Today.Millisecond.ToString(),
                    Salary = 2000
                }
            };
        }
 
    }
}
