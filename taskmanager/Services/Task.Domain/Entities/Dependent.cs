using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Common;

namespace Task.Domain.Entities
{
    public class Dependent : EntityBase
    {
        public int EmployeeKey { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public Employee Employee { get; set; }
        public ICollection<EmployeeBenefit> EmployeeBenefits { get; set; }
    }
}
