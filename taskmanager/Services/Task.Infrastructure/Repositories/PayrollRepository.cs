using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;
using Task.Domain.Entities;
using Task.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Task.Infrastructure.Repositories
{
    public class PayrollRepository : RepositoryBase<EmployeePayroll>, IPayrollRepository
    {
        public PayrollRepository(TaskContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<EmployeePayroll>> GetEmployeePayrolls()
        {
            var emppays =  await _dbContext.EmployeePayrolls.ToListAsync();
            return emppays;

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
