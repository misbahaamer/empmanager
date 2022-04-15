using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;
using Task.Domain.Entities;
using Task.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Task.Application.Features.Tasks.Queries.GetPayrolls;
using AutoMapper;

namespace Task.Infrastructure.Repositories
{
    public class PayrollRepository : RepositoryBase<EmployeePayroll>, IPayrollRepository
    {
        public PayrollRepository(TaskContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<PayrollVM>> GetEmployeePayrolls()
        {
            List<PayrollVM> payrolls = new List<PayrollVM>();
            
            var emppays =  await _dbContext.EmployeePayrolls.ToListAsync();
            var emps = await _dbContext.Employees.ToListAsync();
            var empbens = await _dbContext.EmployeeBenefits.ToListAsync();
            var deplist = await _dbContext.Dependents.ToListAsync();

            foreach (var item in emppays)
            {
                var emp = emps.Where(x => x.Id == item.EmployeeKey).FirstOrDefault();
                var empben = empbens.Where(x => x.EmployeeKey == item.EmployeeKey).FirstOrDefault();
                var deps = deplist.Where(x => x.EmployeeKey == item.EmployeeKey);
                PayrollVM pay = new PayrollVM();
                pay.Id = item.Id;
                pay.EmployeeName = emp.Name;
                pay.PayDate = item.PayDate;
                pay.Salary = emp.Salary;
                pay.TakeHome = item.NetAmount;
                
                int cnt = 0;
         
                List<BreakDown> brs = new List<BreakDown>();
                foreach (var a in deps)
                {
                    
                    BreakDown br = new BreakDown();
                    br.Type = cnt == 0 ? "Self" : "Dependent";
                    br.Count = cnt == 0 ? 1 : deps.ToList().Count;
                    br.Deduction = (decimal)(cnt == 0 ? empben.EmployeeCost : empben.DependentCost);
                    br.Date = item.PayDate;
                    brs.Add(br);
                    
                    cnt++;
                }
                pay.BreakDowns =  new List<BreakDown>(brs);
                payrolls.Add(pay);
                   
            }
            return payrolls;

        }

        public async Task<EmployeePayroll> SaveEmployeePayroll(int id)
        {
            var empben =   _dbContext.EmployeeBenefits.Where(x => x.Id == id).FirstOrDefault();
            var emp = _dbContext.Employees.Where(x => x.Id == empben.EmployeeKey).FirstOrDefault();
            EmployeePayroll pay = new EmployeePayroll();

            pay.PayDate = (DateTime)empben.CreatedDate;
            pay.GrossAmount = emp.Salary;
            pay.Deduction = (decimal)empben.TotalCost;
            pay.NetAmount = pay.GrossAmount - pay.Deduction;
            pay.EmployeeKey = emp.Id;


            await _dbContext.EmployeePayrolls.AddAsync(pay);
            await _dbContext.SaveChangesAsync();

            return pay;
        }
    }
}
