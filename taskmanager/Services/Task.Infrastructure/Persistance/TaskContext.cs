using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task.Domain.Common;
using Task.Domain.Entities;

namespace Task.Infrastructure.Persistance
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<EmployeeBenefit> EmployeeBenefits { get; set; }
        public DbSet<EmployeePayroll> EmployeePayrolls { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;

                        break;

                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Dependent>().HasOne(x => x.Employee).WithMany(y => y.Dependents).HasForeignKey(z => z.EmployeeKey).OnDelete(DeleteBehavior.NoAction);
            model.Entity<EmployeeBenefit>().HasOne(x => x.Benefit).WithMany(y => y.EmployeeBenefits).HasForeignKey(z => z.BenefitKey).OnDelete(DeleteBehavior.NoAction);
  
            model.Entity<EmployeeBenefit>().HasOne(x => x.Employee).WithMany(y => y.EmployeeBenefits).HasForeignKey(z => z.EmployeeKey).OnDelete(DeleteBehavior.NoAction);
            model.Entity<Employee>().HasOne(x => x.EmployeePayroll).WithOne(y =>y.Employee).HasForeignKey<EmployeePayroll>(z => z.EmployeeKey).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
