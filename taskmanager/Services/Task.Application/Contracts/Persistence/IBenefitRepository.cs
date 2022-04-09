using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Entities;

namespace Task.Application.Contracts.Persistence
{
    public interface IBenefitRepository : IAsyncRepository<Benefit>  
    {
        Task<IEnumerable<EmployeeBenefit>> SaveEmployeeBenefit(EmployeeBenefit employeeBenefit);
    }
}
