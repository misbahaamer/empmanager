using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Entities;

namespace Task.Application.Contracts.Persistence
{
    public interface IDependentRepository : IAsyncRepository<Dependent>
    {
        Task<IEnumerable<Dependent>> GetDependentByName(string name);
        Task<IEnumerable<List<Dependent>>> GetDependentsForEmployeeId(int id);

    }
}
