using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Common;

namespace Task.Domain.Entities
{
    public class EmployeePayroll : EntityBase
    {
        public int EmployeeKey { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal Deduction { get; set; }
        public decimal NetAmount { get; set; }
        public DateTime PayDate { get; set; }



        public Employee Employee { get; set; }
    }
}
