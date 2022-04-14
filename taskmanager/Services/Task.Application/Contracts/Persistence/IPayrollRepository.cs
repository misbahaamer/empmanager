using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Entities;

namespace Task.Application.Contracts.Persistence
{
    public interface IPayrollRepository : IAsyncRepository<EmployeePayroll>
    {
        Task<EmployeePayroll> SaveEmployeePayroll(int id);
        Task<IEnumerable<EmployeePayroll>> GetEmployeePayrolls();
    }
}
