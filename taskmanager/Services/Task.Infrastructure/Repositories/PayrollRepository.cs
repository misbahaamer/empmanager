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
    public class PayrollRepository : RepositoryBase<EmployeePayroll>, IPayrollRepository
    {
        public PayrollRepository(TaskContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<EmployeePayroll>> SaveEmployeePayroll(EmployeePayroll employeePayroll)
        {
            throw new NotImplementedException();
        }
    }
}
