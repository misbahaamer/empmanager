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
    public class BenefitRepository : RepositoryBase<Benefit>, IBenefitRepository
    {
        public BenefitRepository(TaskContext dbContext) : base(dbContext)
        {
        }

        
    }
}
