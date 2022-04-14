using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Application.Features.Tasks.Queries.GetPayrolls
{
    public class PayrollVM
    {
        public int Id { get; set; }
        public int EmployeeKey { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal Deduction { get; set; }
        public decimal NetAmount { get; set; }
        public DateTime PayDate { get; set; }
    }
}
