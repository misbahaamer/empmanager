using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Common;

namespace Task.Domain.Entities
{
    public class EmployeeBenefit : EntityBase
    {
        public int EmployeeKey { get; set; }
        public int DependentKey { get; set; }
        public int BenefitKey { get; set; }
        public decimal EmployeeCost { get; set; }
        public decimal DependentCost { get; set; }
        public decimal TotalCost { get; set; }


        public Employee Employee { get; set; }
        public Dependent Dependent { get; set; }
        public Benefit Benefit { get; set; }
    }
}
