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
        public string EmployeeName { get; set; }
        public decimal Salary { get; set; }
        
        public DateTime PayDate { get; set; }
        public decimal TakeHome { get; set; }
        public List<BreakDown> BreakDowns { get; set; }
    }
}
