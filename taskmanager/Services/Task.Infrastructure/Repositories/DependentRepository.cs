using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;
using Task.Domain.Entities;
using Task.Infrastructure.Persistance;

namespace Task.Infrastructure.Repositories
{
    public class DependentRepository : RepositoryBase<Dependent>, IDependentRepository
    {
        public DependentRepository(TaskContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<Dependent>> GetDependentByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<List<Dependent>>> GetDependentsForEmployeeId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
