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

        public async Task<EmployeeBenefit> SaveEmployeeBenefit(EmployeeBenefit employeeBenefit)
        {
            float eCost = 1000/26f;
            float dCost = 500 / 26f;
            float discount = 0.1f;
            float totaldcost = 0;
            List<int> ids = new List<int>();

            var emp = _dbContext.Employees.Where(x => x.Id == employeeBenefit.EmployeeKey).FirstOrDefault();
            var deps = _dbContext.Dependents.Where(x => x.EmployeeKey == employeeBenefit.EmployeeKey);
            employeeBenefit.BenefitKey = 4;
            if (emp.Name.StartsWith("A"))
            {
                employeeBenefit.EmployeeCost = (float)Math.Round(eCost - (eCost * discount), 2) ;
            }
            else
            {
                employeeBenefit.EmployeeCost = (float)Math.Round(eCost, 2);
            }
            foreach (var item in deps)
            {
                if (item.Name.StartsWith("A"))
                {
                    totaldcost = totaldcost + (dCost - (dCost * discount));
                }
                else
                {
                    totaldcost = totaldcost + dCost;
                }
                
         
            }
            employeeBenefit.DependentCost = (float)Math.Round(totaldcost, 2);
            employeeBenefit.TotalCost = (float)Math.Round(employeeBenefit.EmployeeCost + employeeBenefit.DependentCost, 2);

            
            await _dbContext.EmployeeBenefits.AddAsync(employeeBenefit);
            await _dbContext.SaveChangesAsync();


            return employeeBenefit;
        }
    }
}
