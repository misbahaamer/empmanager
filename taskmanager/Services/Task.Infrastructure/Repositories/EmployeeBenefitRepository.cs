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
    public class EmployeeBenefitRepository : RepositoryBase<EmployeeBenefit>, IEmployeeBenefitRepository
    {
        public EmployeeBenefitRepository(TaskContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<EmployeeBenefit>> SaveEmployeeBenefit(EmployeeBenefit employeeBenefit)
        {
            throw new NotImplementedException();
        }
    }
}
