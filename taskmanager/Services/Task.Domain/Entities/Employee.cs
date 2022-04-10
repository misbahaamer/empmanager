using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Common;

namespace Task.Domain.Entities
{
    public class Employee : EntityBase
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }


        public EmployeePayroll EmployeePayroll { get; set; }
        public ICollection<Dependent> Dependents { get; set; }
        public ICollection<EmployeeBenefit> EmployeeBenefits { get; set; }
    }
}
